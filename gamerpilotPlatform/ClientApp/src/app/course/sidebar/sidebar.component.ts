import { Component, OnInit, OnDestroy, DoCheck } from '@angular/core';
import { Router, ActivatedRoute, Params, NavigationEnd } from '@angular/router';
import { CourseService } from '../../core/services/course.service';
import { AuthService } from '../../core/services/auth.service';
import { Subscription, Subject } from 'rxjs';
import { LockedContentComponent} from './locked-content/locked-content.component';
import { takeUntil } from 'rxjs/operators';
import { SnotifyService } from 'ng-snotify';
import { listAnimations, flyInOut } from '../../shared/animation';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  animations: [listAnimations, flyInOut]
})
export class SidebarComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();

  courseName: string;
  course;
  lectures;
  sections;
  dataLoaded = false;

  completedLectures = [];
  currentLectureId: string;

  activeChild = false;

  isLoggedIn;
  isEnrolled;

  minimized = false;
  showNav = false;

  constructor(
    private _router: Router,
    private _activeRoute: ActivatedRoute,
    private _courseService: CourseService,
    private _authService: AuthService,
    private _toastService: SnotifyService
    ) { }

  ngOnInit() {
    this.courseName = this._activeRoute.snapshot.paramMap.get('name');

    this.listenToChildRoutes();

    this._authService.IsAuthed$.subscribe(status => {
      this.isLoggedIn = status;
  });

    this.loadSidebar();
  }

  toggle() {
    this.minimized = !this.minimized;
  }

  toggleNav() {
    this.showNav = !this.showNav;
  }

  loadSidebar() {
    // check if the user is enrolled and load sidebar accordingly
    this._courseService.getUserCourse(this.courseName).pipe(
      takeUntil(this.onDestroy$))
      .subscribe(res => {
          this.isEnrolled = res['data'];
          this.loadCourse(this.courseName);
    });
  }

  previous() {
    if (!this.activeChild || !this.isEnrolled || !this.isLoggedIn ) {
      return;
    }

    const lectureArr = this.lectures.map(x => x.id);
    const index = lectureArr.indexOf(Number(this.currentLectureId));

    if (index > 0) {
      this._router.navigateByUrl(`courses/${this.courseName}/lectures/${lectureArr[index - 1]}`);
    }
  }

  next() {
    if (!this.activeChild || !this.isEnrolled || !this.isLoggedIn ) {
      return;
    }

    const lectureArr = this.lectures.map(x => x.id);
    const index = lectureArr.indexOf(Number(this.currentLectureId));
    const isNotCompleted = this.completedLectures.indexOf(Number(this.currentLectureId)) === -1;

    if (index + 1 < lectureArr.length && isNotCompleted) {
      // complete lecture on server
      this._courseService.completeLecture(this.currentLectureId, this.courseName).pipe(
        takeUntil(this.onDestroy$))
        .subscribe(res => {
          const newCompletedLectures = res['data'];
          this.completedLectures = newCompletedLectures.map(x => x.lectureId);

          this._toastService.success('Keep it up!', {
            timeout: 3000,
            showProgressBar: true,
            closeOnClick: false,
            pauseOnHover: true
          });

        });
    }

    this._router.navigateByUrl(`courses/${this.courseName}/lectures/${lectureArr[index + 1]}`);

  }

  complete() {
    if (!this.activeChild || !this.isEnrolled || !this.isLoggedIn ) {
      return;
    }

    const lectureArr = this.lectures.map(x => x.id);
    const isNotCompleted = this.completedLectures.indexOf(Number(this.currentLectureId)) === -1;

    if (isNotCompleted) {
      // complete lecture on server
      this._courseService.completeLecture(this.currentLectureId, this.courseName)
      .pipe(
      takeUntil(this.onDestroy$))
      .subscribe(res => {
          const newCompletedLectures = res['data'];
          this.completedLectures = newCompletedLectures.map(x => x.lectureId);

          this._toastService.confirm('If another course was released, would you be willing to pay for it?', 'Congratulations!', {
            timeout: 10000,
            showProgressBar: true,
            closeOnClick: false,
            pauseOnHover: true,
            buttons: [
              {text: 'Yes', action: (toast) => {
                this._courseService.sendSatisfaction('YES', this.courseName).pipe(
                  takeUntil(this.onDestroy$))
                  .subscribe();
                this._toastService.remove(toast.id);
              }},
              {text: 'No', action: (toast) => {
                this._courseService.sendSatisfaction('NO', this.courseName).pipe(
                  takeUntil(this.onDestroy$))
                  .subscribe();
                this._toastService.remove(toast.id);
              }},
            ]
          });
        });
    }
  }

  goFirstLesson() {
    const lectureArr = this.lectures.map(x => x.id);
    this._router.navigateByUrl(`courses/${this.courseName}/lectures/${lectureArr[0]}`);

  }


  loadCourse(name: string) {
      this._courseService.getCourse(name)
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(res => {

        if (!res['course']['isReleased'] as Boolean) {
          this._router.navigateByUrl('/courses');
        }

        const enrolledResult = res['enrolled'] as boolean;

        if (!enrolledResult) {
          this.course = res['course'];
          this.lectures = this.course.lectures;
          this.sections = this.course.sections;

        } else {
          this.course = res['course'];
          this.lectures = this.course.lectures;
          const completedLectureArr = res['completedLectures'];
          this.completedLectures = completedLectureArr.map(x => x.lectureId);
          this.sections = this.course.sections;

        }
        if (!this.course) {
          // if no course matched name param in url
          this._router.navigateByUrl('/courses');
        }

        // sort the lectures by their order in the course
  /*       this.lectures.sort(function(a, b) {
          return a.displayOrder - b.displayOrder;
        }); */

        this.dataLoaded = true;
      });
  }

  listenToChildRoutes() {
    // check on initial page load
    if (this._activeRoute.children.length > 0) {
      this._activeRoute.firstChild.params
      .pipe(takeUntil(this.onDestroy$))
      .subscribe((params: Params) => {
           this.currentLectureId = params['id'];
           this.activeChild = true;
       });
     } else {
        this.activeChild = false;
     }

    // listen to router events
    this._router.events.pipe(takeUntil(this.onDestroy$)).
    subscribe(e => {
      if (e instanceof NavigationEnd && this._activeRoute.children.length > 0) {
        this._activeRoute.firstChild.params
        .pipe(takeUntil(this.onDestroy$))
        .subscribe((params: Params) => {
          this.currentLectureId = params['id'];
          this.activeChild = true;
      });
      } else {
        this.activeChild = false;

      }
    });
  }

  enrollUser(enroll: boolean) {
    if (!this.isLoggedIn) {
      this._router.navigateByUrl('/login');
      return;
    }

    this._courseService.enroll(this.courseName)
    .pipe(takeUntil(this.onDestroy$))
    .subscribe(res => {
        this.isEnrolled = true;
        this.loadCourse(this.courseName);

        const lectureIds = this.lectures.map(x => x.id);
        this._router.navigateByUrl(`/courses/${this.courseName}/lectures/${lectureIds[0]}`);

        this._toastService.success('Let\'s get started!', {
          timeout: 2000,
          showProgressBar: true,
          closeOnClick: false,
          pauseOnHover: true
        });
    }, err => {
        console.log(err);
    });
  }

  isCompleted(id) {
    return this.completedLectures.indexOf(Number(id)) > -1;
  }

  isCurrent(id) {
    return Number(this.currentLectureId) === Number(id);
  }

  isLast() {
    if (typeof this.currentLectureId === 'undefined' || typeof this.lectures === 'undefined') {
      return false;
    }  else {
      return this.lectures.map(x => x.id).indexOf(Number(this.currentLectureId)) === this.lectures.length - 1;
    }
  }

  isFirst() {
    if (typeof this.currentLectureId === 'undefined' || typeof this.lectures === 'undefined') {
      return false;
    }  else {
      return this.lectures.map(x => x.id).indexOf(Number(this.currentLectureId)) === 0;
    }
  }

  isInBetween() {
    if (typeof this.currentLectureId === 'undefined' || typeof this.lectures === 'undefined') {
      return false;
    }  else {
      const index = this.lectures.map(x => x.id).indexOf(Number(this.currentLectureId));
      return index !== 0 && index !== this.lectures.length - 1;
    }
  }



  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}




import { Component, OnInit, OnDestroy, DoCheck } from '@angular/core';
import { Router, ActivatedRoute, Params, NavigationEnd } from '@angular/router';
import { CourseService } from '../../core/services/course.service';
import { AuthService } from '../../core/services/auth.service';
import { Subscription, Subject } from 'rxjs';
import { LockedContentComponent} from './locked-content/locked-content.component';
import { takeUntil } from 'rxjs/operators';
import { SnotifyService } from 'ng-snotify';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();

  private courseName: string;
  private course;
  private lectures;
  private dataLoaded: boolean;

  completedLectures = [];
  currentLectureId: number;

  private isLoggedIn;
  private isEnrolled;

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

    this.isLoggedIn = this._authService.isLoggedIn();

    this.loadSidebar();
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
    const lectureArr = this.lectures.map(x => x.id);
    const index = lectureArr.indexOf(Number(this.currentLectureId));

    if (index > 0) {
      this._router.navigateByUrl(`courses/${this.courseName}/lectures/${lectureArr[index - 1]}`);
    }
  }

  next() {
    const lectureArr = this.lectures.map(x => x.id);
    const index = lectureArr.indexOf(Number(this.currentLectureId));
    const isNotCompleted = this.completedLectures.indexOf(Number(this.currentLectureId)) === -1;

    if (index + 1 < lectureArr.length && isNotCompleted) {
      // complete lecture on server
      this._courseService.completeLecture(Number(this.currentLectureId), this.courseName).pipe(
        takeUntil(this.onDestroy$))
        .subscribe(res => {
          const newCompletedLectures = res['data'];
          this.completedLectures = newCompletedLectures.map(x => x.lectureId);

          this._toastService.success('Keep it up!', {
            timeout: 2000,
            showProgressBar: true,
            closeOnClick: false,
            pauseOnHover: true
          });

        });
    }

    this._router.navigateByUrl(`courses/${this.courseName}/lectures/${lectureArr[index + 1]}`);

  }

  complete() {
    const lectureArr = this.lectures.map(x => x.id);
    const isNotCompleted = this.completedLectures.indexOf(Number(this.currentLectureId)) === -1;

    if (isNotCompleted) {
      // complete lecture on server
      this._courseService.completeLecture(Number(this.currentLectureId), this.courseName)
      .pipe(
      takeUntil(this.onDestroy$))
      .subscribe(res => {
          const newCompletedLectures = res['data'];
          this.completedLectures = newCompletedLectures.map(x => x.lectureId);

          this._toastService.confirm('Example body content', 'Example title', {
            timeout: 10000,
            showProgressBar: true,
            closeOnClick: false,
            pauseOnHover: true,
            buttons: [
              {text: 'Yes', action: (toast) => {
                console.log('Clicked yes');
                this._toastService.remove(toast.id);
              }},
              {text: 'No', action: (toast) => {
                console.log('Clicked no');
                this._toastService.remove(toast.id);
              }},
            ]
          });
        });
    }
  }


  loadCourse(name: string) {
      this._courseService.getCourse(name)
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(res => {
        const enrolledResult = res['enrolled'] as boolean;

        if (!enrolledResult) {
          this.course = res['course'];
          this.lectures = this.course.lectures;
        } else {
          this.course = res['course'];
          this.lectures = this.course.lectures;
          const completedLectureArr = res['completedLectures'];
          this.completedLectures = completedLectureArr.map(x => x.lectureId);
        }
        if (!this.course) {
          // if no course matched name param in url
          this._router.navigateByUrl('/courses');
        }

        this.dataLoaded = true;
      });
  }

  listenToChildRoutes() {
    if (this._activeRoute.children.length > 0) {
     this._activeRoute.firstChild.params
     .pipe(takeUntil(this.onDestroy$))
     .subscribe((params: Params) => {
          this.currentLectureId = params['id'];
      });
    }

    this._router.events.pipe(takeUntil(this.onDestroy$)).
    subscribe(e => {
      if (e instanceof NavigationEnd && this._activeRoute.children.length > 0) {
        this._activeRoute.firstChild.params
        .pipe(takeUntil(this.onDestroy$))
        .subscribe((params: Params) => {
          this.currentLectureId = params['id'];
      });
      }
    });
  }

  enrollUser(enroll: boolean) {
    this._courseService.enroll(this.courseName)
    .pipe(takeUntil(this.onDestroy$))
    .subscribe(res => {
        this.isEnrolled = true;
        this.loadCourse(this.courseName);

        const lectureIds = this.lectures.map(x => x.id);
        this._router.navigateByUrl(`/courses/${this.courseName}/lectures/${lectureIds[0]}`);

        this._toastService.success('Keep it up!', {
          timeout: 2000,
          showProgressBar: true,
          closeOnClick: false,
          pauseOnHover: true
        });
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




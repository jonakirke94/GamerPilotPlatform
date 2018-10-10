import { Component, OnInit, OnDestroy, DoCheck } from '@angular/core';
import { Router, ActivatedRoute, Params, NavigationEnd } from '@angular/router';
import { Subscription, Subject } from 'rxjs';
import { LockedContentComponent} from './locked-content/locked-content.component';
import { takeUntil } from 'rxjs/operators';
import { SnotifyService } from 'ng-snotify';
import { listAnimations, flyInOut } from '../../../shared/animation';
import { CourseService } from '../../../core/services/course.service';
import { AuthService } from '../../../core/services/auth.service';
import { Feedback } from '../../../../models/feedback';
import { Course } from '../../../../models/course';
import { Section } from '../../../../models/section';
import { LectureService } from '../../../core/services/lecture.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  animations: [listAnimations, flyInOut]
})
export class SidebarComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();

  url: string;
  course: Course;
  lectures: any[];
  feedback: Feedback;
  sections: Section[];
  completedLectures = [];
  currentLectureId: string;

  courseState = {
    dataLoaded: false,
    activeChild: false,
    isLoggedIn: false,
    isEnrolled: false,
    completedCourse: false
  };

  minimized = false;
  showNav = false;

  constructor(
    private _router: Router,
    private _activeRoute: ActivatedRoute,
    private _courseService: CourseService,
    private _authService: AuthService,
    private _toastService: SnotifyService,
    private _lectureService: LectureService
    ) { }

  ngOnInit() {
    this.url = this._activeRoute.snapshot.paramMap.get('name');

    this.listenToChildRoutes();

    this._authService.IsAuthed$.subscribe(status => {
      this.courseState.isLoggedIn = status;
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
    this._courseService.getUserCourse(this.url).pipe(
      takeUntil(this.onDestroy$))
      .subscribe(res => {
          this.courseState.isEnrolled = res['isEnrolled'];
          this.courseState.completedCourse = res['isCompleted'];
          this.loadCourse(this.url);
    });
  }

  previous() {
    if (!this.courseState.activeChild || !this.courseState.isEnrolled || !this.courseState.isLoggedIn ) {
      return;
    }

    const lectureArr = this.lectures.map(x => x.id);
    const index = lectureArr.indexOf(Number(this.currentLectureId));

    if (index > 0) {
      this._router.navigateByUrl(`courses/${this.url}/lectures/${lectureArr[index - 1]}`);
    }
  }

  next() {
    if (!this.courseState.activeChild || !this.courseState.isEnrolled || !this.courseState.isLoggedIn ) {
      return;
    }

    const lectureArr = this.lectures.map(x => x.id);
    const index = lectureArr.indexOf(Number(this.currentLectureId));
    const isNotCompleted = this.completedLectures.indexOf(Number(this.currentLectureId)) === -1;

    if (isNotCompleted) {
      // complete lecture on server
      this._lectureService.completeLecture(this.currentLectureId, this.url, false).pipe(
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

          this.goToNextLecture();

        });
    // if already completed just navigate to the next lecture
    } else if (index + 1 < lectureArr.length) {
      // go to next if not on last lecture
      this._router.navigateByUrl(`courses/${this.url}/lectures/${lectureArr[index + 1]}`);
    } else {
      // go to first lecture
      this._router.navigateByUrl(`courses/${this.url}/lectures/${lectureArr[0]}`);
    }
  }

  goToNextLecture() {
    const lectureArr = this.lectures.map(x => x.id);

    let nextArrIndex: number;
    for (let i = 0; i < lectureArr.length; i++) {
      const id = lectureArr[i];
      if (this.completedLectures.indexOf(Number(id)) === -1) {
        nextArrIndex = lectureArr.indexOf(Number(id));
        break;
      }
    }

    this._router.navigateByUrl(`courses/${this.url}/lectures/${lectureArr[nextArrIndex]}`);
  }

  complete() {
    if (!this.courseState.activeChild || !this.courseState.isEnrolled || !this.courseState.isLoggedIn ) {
      return;
    }

    const lectureArr = this.lectures.map(x => x.id);
    const isNotCompleted = this.completedLectures.indexOf(Number(this.currentLectureId)) === -1;

    if (isNotCompleted) {
      // complete lecture on server
      this._lectureService.completeLecture(this.currentLectureId, this.url, true)
      .pipe(
      takeUntil(this.onDestroy$))
      .subscribe(res => {
          const newCompletedLectures = res['data'];
          this.completedLectures = newCompletedLectures.map(x => x.lectureId);
          this.courseState.completedCourse = true;

          // send to course home view where feedback will be showed
          this._router.navigateByUrl(`courses/${this.url}`);
        });
    }
  }

  loadCourse(name: string) {
      this._courseService.getCourse(name)
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(res => {
        this.course = res['course'] as Course;

        if (!this.course.isReleased) {
          this._router.navigateByUrl('/courses');
        }

        this.lectures = this.course.lectures;
        this.sections = this.course.sections;

        // sort the sectins by their order in the course
        this.sections.sort(function(a, b) {
          return a.order - b.order;
        });

        const enrolledResult = res['enrolled'] as boolean;
        this.feedback = res['feedback'] as Feedback;

        if (enrolledResult) {
          const completedLectureArr = res['completedLectures'];
          this.completedLectures = completedLectureArr.map(x => x.lectureId);
        }

        if (!this.course) {
          // if no course matched name param in url
          this._router.navigateByUrl('/courses');
        }

        // sort the lectures by their order in the course
        this.lectures.sort(function(a, b) {
          return a.displayOrder - b.displayOrder;
        });

        this.courseState.dataLoaded = true;
      });
  }

  listenToChildRoutes() {
    // check on initial page load
    if (this._activeRoute.children.length > 0) {
      this._activeRoute.firstChild.params
      .pipe(takeUntil(this.onDestroy$))
      .subscribe((params: Params) => {
           this.currentLectureId = params['id'];
           this.courseState.activeChild = true;
       });
     } else {
        this.courseState.activeChild = false;
     }

    // listen to router events
    this._router.events.pipe(takeUntil(this.onDestroy$)).
    subscribe(e => {
      if (e instanceof NavigationEnd && this._activeRoute.children.length > 0) {
        this._activeRoute.firstChild.params
        .pipe(takeUntil(this.onDestroy$))
        .subscribe((params: Params) => {
          this.currentLectureId = params['id'];
          this.courseState.activeChild = true;
      });
      } else {
        this.courseState.activeChild = false;
      }
    });
  }

  enrollUser(enroll: boolean) {
    if (!this.courseState.isLoggedIn) {
      this._router.navigateByUrl('auth/login');
      return;
    }

    this._courseService.enroll(this.url)
    .pipe(takeUntil(this.onDestroy$))
    .subscribe(res => {
        this.courseState.isEnrolled = true;
        this.loadCourse(this.url);

        const lectureIds = this.lectures.map(x => x.id);
        this._router.navigateByUrl(`/courses/${this.url}/lectures/${lectureIds[0]}`);

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
      /* return this.lectures.map(x => x.id).indexOf(Number(this.currentLectureId)) === this.lectures.length - 1; */
      return this.lectures.length - this.completedLectures.length  === 1 && !this.isCompleted(this.currentLectureId);
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
    return !this.isFirst() && !this.isLast();
  }

  showLockedComponent() {
    return !this.courseState.isEnrolled || !this.courseState.isLoggedIn;
  }

  showFeedbackComponent() {
    return !this.courseState.activeChild && this.courseState.completedCourse && this.courseState.isEnrolled && this.courseState.isLoggedIn;
  }

  showNextLectureComponent() {
    return !this.courseState.activeChild && !this.courseState.completedCourse && this.courseState.isEnrolled && this.courseState.isLoggedIn;
  }


  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}




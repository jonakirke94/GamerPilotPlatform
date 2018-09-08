import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params, NavigationEnd } from '@angular/router';
import { CourseService } from '../../core/services/course.service';
import { AuthService } from '../../core/services/auth.service';
import { Subscription, Subject } from 'rxjs';
import { LockedContentComponent} from './locked-content/locked-content.component';
import { takeUntil } from 'rxjs/operators';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();

  course;
  lectures;
  completedLectures;
  currentLectureId;

  isLoggedIn;
  isEnrolled;
  courseName: string;

  constructor(
    private _router: Router,
    private _activeRoute: ActivatedRoute,
    private _courseService: CourseService,
    private _authService: AuthService
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

          // temp if else not needed -only calling one method and doing the resolve on server
          if (!this.isLoggedIn || !this.isEnrolled) {
            console.log('NOT ENROLLED!!');
            this.loadCourse(this.courseName);
          } else {
            // load cousre with user's progress
            console.log('userIsEnrolled!!');
            this.loadCourse(this.courseName);
          }
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

    if (index + 1 < lectureArr.length) {
      // complete lecture on server
      this._router.navigateByUrl(`courses/${this.courseName}/lectures/${lectureArr[index + 1]}`);
    }

    if (index === lectureArr.length) {
      // complete course;
    }
  }



  isCompleted(id) {
    return this.completedLectures.indexOf(id) > -1;
  }


  loadCourse(name: string) {
      this._courseService.getCourse(name)
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(res => {
        const enrolledResult = res['enrolled'] as boolean;
        console.log('COURSE', res);

        if (!enrolledResult) {
          this.course = res['course'];
          this.lectures = this.course.lectures;
        } else {
          this.course = res['course'];
          this.lectures = this.course.lectures;
          this.completedLectures = res['completedLectures'];
        }
        if (!this.course) {
          // if no course matched name param in url
          this._router.navigateByUrl('/courses');
        }
      });
  }

  listenToChildRoutes() {
    if (this._activeRoute.children.length > 0) {
     this._activeRoute.firstChild.params.pipe(takeUntil(this.onDestroy$))
     .subscribe((params: Params) => {
          this.currentLectureId = params['id'];
      });
    }

    this._router.events.pipe(takeUntil(this.onDestroy$)).
    subscribe(e => {
      if (e instanceof NavigationEnd) {
        this._activeRoute.firstChild.params
        .pipe(takeUntil(this.onDestroy$))
        .subscribe((params: Params) => {
          this.currentLectureId = params['id'];
      });
      }
    });
  }

  enrollUser(enroll: boolean) {
    console.log('in enrollUser');
    this._courseService.enroll(this.courseName)
    .pipe(takeUntil(this.onDestroy$))
    .subscribe(res => {
        this.isEnrolled = true;
        this.loadCourse(this.courseName);
    });
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}




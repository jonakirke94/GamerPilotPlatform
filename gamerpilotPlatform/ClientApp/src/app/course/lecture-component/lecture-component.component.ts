import { Component, OnInit, OnDestroy } from '@angular/core';
import { Course } from '../../../models/course';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { CourseService } from '../../core/services/course.service';
import { Lecture } from '../../../models/lecture';
import { AuthService } from '../../core/services/auth.service';
import { Subscription, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-lecture-component',
  templateUrl: './lecture-component.component.html',
  styleUrls: ['./lecture-component.component.scss']
})
export class LectureComponentComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();

  dataLoaded = false;

  isLoggedIn;
  isEnrolled;
  lecture;

  courseName: string;
  lectureId: string;

  constructor(
    private _activeRoute: ActivatedRoute,
    private _courseService: CourseService,
    private _router: Router) { }


  ngOnInit() {
    this.fetchParamData();
  }

  fetchParamData() {
    this._activeRoute.params
    .pipe(
      takeUntil(this.onDestroy$
    ))
    .subscribe((params: Params) => {
    this._activeRoute.parent.params
    .pipe(
      takeUntil(this.onDestroy$
    ))
    .subscribe((parentParams: Params) => {
        this.courseName = parentParams['name'];
        this.lectureId = params['id'];

          this.fetchLecture(this.courseName, this.lectureId);
      });
    });
  }

  fetchLecture(name: string, id: string) {
      this._courseService.getLecture(name, id)
      .pipe(
        takeUntil(this.onDestroy$
      ))
      .subscribe(res => {
        this.lecture = res['data'];
        this.dataLoaded = true;
      },
      err => {
        // if user was not enrolled
        if (err.status = 400) {
          this._router.navigateByUrl(`/courses/${this.courseName}`);
        }
      });
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}

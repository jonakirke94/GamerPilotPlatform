import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { flyInOut } from '../../../shared/animation';
import { CourseService } from '../../../core/services/course.service';
import { LectureService } from '../../../core/services/lecture.service';

@Component({
  selector: 'app-lecture-component',
  templateUrl: './lecture-component.component.html',
  styleUrls: ['./lecture-component.component.scss'],
  animations: [flyInOut]
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
    private _router: Router,
    private _lectureService: LectureService
    ) { }


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
      this._lectureService.getLecture(name, id)
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

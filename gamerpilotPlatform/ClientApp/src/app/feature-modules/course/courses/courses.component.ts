import { Component, OnInit, OnDestroy } from '@angular/core';
import {  Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';
import { listAnimationSlow } from '../../../shared/animation';
import { CourseService } from '../../../core/services/course.service';
import { Course } from '../../../../models/course';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss'],
  animations: [listAnimationSlow]

})
export class CoursesComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();
  courses: Course[];
  dataLoaded = false;

  constructor(private _courseService: CourseService, private _router: Router) { }

  ngOnInit() {
    this.fetchCourses();
  }

  goToCourse(isReleased: boolean, urlName: string) {
    if (isReleased) {
      this._router.navigateByUrl(`/courses/${urlName}`);
    }
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }

  fetchCourses() {
    this._courseService.getCourses()
    .pipe(
      takeUntil(this.onDestroy$
    ))
    .subscribe(res => {
      this.courses = res['data'];
      console.log(this.courses);
      this.courses.sort(function(a, b) {
          if (a.isReleased) {
            return -1;
          }
          if (b.isReleased) {
            return 1;
          }
      });
      this.dataLoaded = true;
    });
  }

}

import { Component, OnInit, OnDestroy } from '@angular/core';
import { CourseService } from '../../core/services/course.service';
import {  Subject } from 'rxjs';
import { Course } from '../../../models/course';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';
import { listAnimationSlow } from '../../shared/animation';

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
      this.dataLoaded = true;
    });
  }

}

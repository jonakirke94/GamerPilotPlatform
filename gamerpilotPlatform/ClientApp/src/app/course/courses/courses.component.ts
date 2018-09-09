import { Component, OnInit, OnDestroy } from '@angular/core';
import { CourseService } from '../../core/services/course.service';
import { Subscription, Subject } from 'rxjs';
import { Course } from '../../../models/course';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();
  courses: Course[];

  constructor(private _courseService: CourseService) { }

  ngOnInit() {
    this.fetchCourses();
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
    });
  }

}

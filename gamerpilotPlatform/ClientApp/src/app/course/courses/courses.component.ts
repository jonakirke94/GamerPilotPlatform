import { Component, OnInit, OnDestroy } from '@angular/core';
import { CourseService } from '../../core/services/course.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit, OnDestroy {
  courses: any = [];
  $courses: Subscription;

  constructor(private _courseService: CourseService) { }

  ngOnInit() {
    this.fetchCourses();
  }

  ngOnDestroy() {
    this.$courses.unsubscribe();
  }

  fetchCourses() {
    this.$courses = this._courseService.getCourses().subscribe(res => {
      this.courses = res['data'];
    });
  }

  showCourse(course) {
    console.log(course.id);
  }

}

import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../core/services/course.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {
  courses: any = [];

  constructor(private _courseService: CourseService) { }

  ngOnInit() {
    this.courses = this._courseService.getCourses();
  }

  showCourse(course) {
    console.log(course.id);
  }

}

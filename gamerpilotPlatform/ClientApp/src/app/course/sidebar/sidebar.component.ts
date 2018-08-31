import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import * as $ from 'jquery';
import { CourseService } from '../../core/services/course.service';
import { Course } from '../../../models/course';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  showOutlet = false;
  course: Course;

  constructor(private _router: Router, private _activedRoute: ActivatedRoute, private _courseService: CourseService) { }

  ngOnInit() {
    const nameParam: string = this._activedRoute.snapshot.paramMap.get('name');
    this.loadCourse(nameParam);
    // retrieve route and check if the course exists
  }

  loadCourse(name: string) {
      this._courseService.getCourse(name).subscribe(res => {
        console.log(res['data'], 'res');
        this.course = res['data'];

        if (!this.course) {
          // if no course matched name param in url
          this._router.navigateByUrl('/courses');
        }
      });
  }
}

/*
  toggle(): void {
    $('#sidebar').toggleClass('active');
} */


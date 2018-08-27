import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-course-sidebar',
  templateUrl: './course-sidebar.component.html',
  styleUrls: ['./course-sidebar.component.scss']
})
export class CourseSidebarComponent implements OnInit {
  public testname: string;

  constructor(private route: ActivatedRoute) {
      console.log(this.route.snapshot.paramMap.get('name'));
  }

  ngOnInit() {

  }

  toggle(): void {
    $('#sidebar').toggleClass('active');

}

}

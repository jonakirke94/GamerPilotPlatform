import { Component, OnInit, Input } from '@angular/core';
import { CourseCardComponent } from '../../shared/course-card/course-card.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']

})

export class HomeComponent {

  courses: any = [];

  constructor() {}

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.courses.push({
      topic: 'Communication',
      fa: 'fas fa-headset',
      soon: false,
      id: 1,
    });

    this.courses.push({
      topic: 'Strategy',
      fa: 'fab fa-accessible-icon',
      soon: true,
      id: 2,
    });

    this.courses.push({
      topic: 'Teamwork',
      fa: 'fas fa-allergies',
      soon: true,
      id: 3,
    });

    this.courses.push({
      topic: 'Concentration',
      fa: 'fas fa-address-book',
      soon: true,
      id: 4,
    });

  }

  goCourse(id: string) {
    console.log(id);
  }
}

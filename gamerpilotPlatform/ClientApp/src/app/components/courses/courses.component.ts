import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {
  courses: any = [];

  constructor() { }

  ngOnInit() {
    this.courses.push({
      topic: 'Communication',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-headset',
      soon: false,
      id: 1,
    });

    this.courses.push({
      topic: 'Strategy',
      imgUrl: 'https://picsum.photos/600/600/?random',
      fa: 'fab fa-accessible-icon',
      soon: false,
      id: 2,
    });

    this.courses.push({
      topic: 'Teamwork',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-allergies',
      soon: false,
      id: 3,
    });

    this.courses.push({
      topic: 'Concentration',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-address-book',
      soon: false,
      id: 4,
    });

    this.courses.push({
      topic: 'Concentration111',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-address-book',
      soon: false,
      id: 5,
    });


    this.courses.push({
      topic: 'Concentration111',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-address-book',
      soon: true,
      id: 6,
    });
  }

  showCourse(course) {
    console.log(course.id);
  }

}

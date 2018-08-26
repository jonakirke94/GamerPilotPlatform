import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  courses: any = [];
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
  }


  getCourses() {
    const courses = [];

    courses.push({
      topic: 'Communication',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-headset',
      soon: false,
      id: 1,
    });

    courses.push({
      topic: 'Strategy',
      imgUrl: 'https://picsum.photos/600/600/?random',
      fa: 'fab fa-accessible-icon',
      soon: false,
      id: 2,
    });

    courses.push({
      topic: 'Teamwork',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-allergies',
      soon: false,
      id: 3,
    });

    courses.push({
      topic: 'Concentration',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-address-book',
      soon: false,
      id: 4,
    });

    courses.push({
      topic: 'Concentration111',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-address-book',
      soon: false,
      id: 5,
    });


    courses.push({
      topic: 'Concentration111',
      imgUrl: 'https://picsum.photos/600/600?random',
      fa: 'fas fa-address-book',
      soon: true,
      id: 6,
    });

    return courses;
  }
}

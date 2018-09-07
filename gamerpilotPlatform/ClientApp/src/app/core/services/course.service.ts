import { Injectable, Inject, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CourseService implements OnDestroy {
  baseUrl: string;
  activeCourse;

  constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
  }


  getCourse(name: string) {
    const req = this.http
    .get(this.baseUrl + `api/courses/${name}`);

    req.subscribe( res => {
      this.activeCourse = res['data'];
    });

    return req;
  }

  getLecture(id: string) {
    return this.http
    .get(this.baseUrl + `api/courses/lecture/${id}`);
  }

  getCourses() {
    return this.http
    .get(this.baseUrl + `api/courses/`);
  }

  ngOnDestroy() {
    
  }
}

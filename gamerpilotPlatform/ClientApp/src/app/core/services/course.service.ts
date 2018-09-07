import { Injectable, Inject, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CourseService implements OnDestroy {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
  }


  getCourse(name: string) {
    return this.http
    .get(this.baseUrl + `api/courses/${name}`);
  }

  getLecture(name: string, id: string)  {
    return this.http
    .get(this.baseUrl + `api/courses/${name}/lecture/${id}`);
  }

  getCourses() {
    return this.http
    .get(this.baseUrl + `api/courses/`);
  }

  ngOnDestroy() {

  }
}

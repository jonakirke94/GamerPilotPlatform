import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
  }


  getCourse(name: string) {
    return this.http
    .get(this.baseUrl + `api/course/getcourse/${name}`);
  }



  getCourses() {
    return this.http
    .get(this.baseUrl + `api/course/getall`);
  }
}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LectureService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl + 'api/lectures/';
  }

  getLecture(name: string, id: string)  {
    return this.http
    .get(this.baseUrl + `${name}/lecture/${id}`);
  }

  completeLecture(id: string, urlName: string, isLastLecture: boolean) {
    return this.http
    .post(this.baseUrl + `complete`, {id, urlName, isLastLecture});
  }



}

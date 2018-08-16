import { Injectable, Inject } from '@angular/core';
import { StorageService } from './storage.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl: string;

  constructor(private http: HttpClient, private _storage: StorageService, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
  }

  getBooks() {
    return this.http
      .get(this.baseUrl + 'api/books/getAll');
  }
}

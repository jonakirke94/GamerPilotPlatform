import { Injectable, EventEmitter, Output, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StorageService } from './storage.service';
import { Inject } from '@angular/core';
import 'rxjs/add/operator/switchMap';
import { tap, shareReplay } from 'rxjs/operators';




import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  @Output() IsAuthed$: BehaviorSubject <boolean> = new BehaviorSubject (this.hasToken());
  baseUrl: string;

  constructor(private http: HttpClient, private _storage: StorageService, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
    console.log(this.baseUrl, 'base');
  }

  signup(username: string, email: string, password: string) {
    return this.http
      .post(this.baseUrl + 'api/accounts/signup', {
        email,
        username,
        password
      }).pipe(
      tap(res => {
        this.setSession(res);
      }),
      shareReplay()
    );
  }

  login(email: string, password: string) {
    this.logout();

    return this.http
      .post(this.baseUrl + 'api/accounts/login', {
        email,
        password
      })
      .pipe(
      tap(res => {
        this.setSession(res);

      }),
      shareReplay()
    );
  }


  setSession(info: any) {
    this._storage.saveTokens(info);
    this.IsAuthed$.next(true);
  }

  hasToken() {
     return !!this._storage.getToken() ? true : false;
  }

  logout() {
    this.IsAuthed$.next(false);
    this._storage.destroyTokens();
  }
}

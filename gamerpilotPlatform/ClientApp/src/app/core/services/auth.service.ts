import { Injectable, EventEmitter, Output } from '@angular/core';
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
  @Output() IsAuthed: EventEmitter<boolean> = new EventEmitter();
  baseUrl: string;

/*   loggedIn = new BehaviorSubject<boolean>(false);
 */

  constructor(private http: HttpClient, private _storage: StorageService, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
  }

  signup(username: string, email: string, password: string) {
    return this.http
      .post(this.baseUrl + 'api/account/signup', {
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
      .post(this.baseUrl + 'api/account/login', {
        email,
        password
      }).pipe(
      tap(res => {
        this.setSession(res);

      }),
      shareReplay()
    );
  }


  setSession(info: any) {
    this._storage.saveTokens(info);
    this.IsAuthed.emit(true);
  }

  public isLoggedIn() {
    let res = false;

    const token = this._storage.getToken();
    if (token) {
      res = true;
      this.IsAuthed.emit(true);
    } else {
      this.IsAuthed.emit(false);
    }

    return res;

  }

  logout() {
    this.IsAuthed.emit(false);
    this._storage.destroyTokens();
  }
}

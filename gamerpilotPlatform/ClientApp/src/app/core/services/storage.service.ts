import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }


  public saveTokens(info: any) {
    localStorage.setItem('access_token', info.token);
    localStorage.setItem('refresh_token', info.refreshToken);
  }

  getToken(): string {
    return localStorage.getItem('access_token');
  }

  remember() {
    localStorage.setItem('rememberMe', 'true');
  }

  rememberMe(): boolean {
    return !!localStorage.getItem('rememberMe') ? true : false;
  }

  public getRefreshToken(): string {
    return localStorage.getItem('refresh_token');
  }

  public destroyTokens() {
    localStorage.clear();
  }
}

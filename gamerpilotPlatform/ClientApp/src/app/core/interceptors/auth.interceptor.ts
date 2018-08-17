import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest, HttpResponse, HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/observable/throw';
import 'rxjs/Observable';

import { AuthService } from '../services/auth.service';
import { StorageService } from '../services/storage.service';
import { Observable } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';



@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    baseUrl: string;

    constructor(private router: Router, private _auth: AuthService, private _storage: StorageService,
          private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
        this.baseUrl = _baseUrl;
    }

    private applyCredentials = function (req) {
            const token = this._storage.getToken();

                return req.clone({
                    headers: req.headers.set('Authorization', 'Bearer ' + token)
                });
    };

    private logout() {
        this._auth.logout();
        this.router.navigateByUrl('/home');
    }

    intercept(req: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(this.applyCredentials(req)).pipe(
            catchError(err => {

                if (err instanceof HttpErrorResponse) {



                    if (err.status === 401 && err.headers.get('Token-Expired')) {

                        // fetch tokens
                        const token = this._storage.getToken();
                        const refreshToken = this._storage.getRefreshToken();
                        // attempt to refresh tokens on the server
                        return this.http
                        .post(this.baseUrl + 'api/token/refresh', {
                            token,
                            refreshToken
                        }).pipe(
                        switchMap(res => {
                          if (!res) {
                              this.logout();
                          }
                          this._auth.setSession(res);
                          // resend request with updated header
                          return next.handle(this.applyCredentials(req));
                        }));
                    } else {
                        this.logout();
                    }

                }

                return Observable.throw(err);


            })


        );
    }

}

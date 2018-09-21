import { Injectable, OnDestroy } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { takeUntil } from 'rxjs/operators';
import { SnotifyService } from 'ng-snotify';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, OnDestroy {
  private onDestroy$ = new Subject<void>();
  isLoggedIn: boolean;

  constructor(private _auth: AuthService, private router: Router, private _toastService: SnotifyService) {}


  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

      this._auth.IsAuthed$
      .pipe(
        takeUntil(this.onDestroy$
      ))
      .subscribe(isLogged => {

        if (!isLogged) {
          this._toastService.error('Oops you have to log in or sign up to view that page!', {
            timeout: 5000,
            position: 'centerTop',
            showProgressBar: true,
            closeOnClick: true,
            pauseOnHover: true
          });
          this.router.navigateByUrl('/login');
        }
          this.isLoggedIn = true;
        });

      return this.isLoggedIn;
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}

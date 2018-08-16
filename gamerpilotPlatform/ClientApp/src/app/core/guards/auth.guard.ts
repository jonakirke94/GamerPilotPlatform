import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  isLoggedIn: boolean;

  constructor(private _auth: AuthService, private router: Router) {}


  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

      this._auth.isLoggedIn().subscribe(isLogged => {
        if (!isLogged) {
          this.router.navigateByUrl('/home');
        }
          this.isLoggedIn = true;
        }).unsubscribe();

      return this.isLoggedIn;
  }
}

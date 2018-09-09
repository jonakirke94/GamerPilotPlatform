import { Component, OnInit, HostListener, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { AuthService } from '../../../core/services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-layout-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();

  isLoggedin$: Observable<boolean>;
  isAuthed: boolean;

  constructor(private _auth: AuthService,
    private router: Router) {

      }

  ngOnInit() {
    this.listenToAuthChanges();
    this.initNavbar();
  }

  private listenToAuthChanges() {
    this._auth.IsAuthed
    .pipe(
      takeUntil(this.onDestroy$
    ))
    .subscribe(status => this.changeAuthStatus(status));
  }

  private changeAuthStatus(status: boolean): void {
      this.isAuthed = status;
  }

  private initNavbar() {
    const menus = Array.from(document.querySelectorAll('.mobile-menu-toggle'));
    menus.forEach(function(btn) {
      return btn.addEventListener('click', function() {
        document.querySelector('.main-nav').classList.toggle('active');
      });
    });
  }

  private logout() {
    this._auth.logout();
    // this.router.navigateByUrl('/home');
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }

}

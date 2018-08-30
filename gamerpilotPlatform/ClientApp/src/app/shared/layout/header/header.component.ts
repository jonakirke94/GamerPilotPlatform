import { Component, OnInit, HostListener } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../../../core/services/auth.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-layout-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  isLoggedin$: Observable<boolean>;
  isAuthed: boolean;

    constructor(private _auth: AuthService,
      private router: Router) {

       }

    ngOnInit() {
      this._auth.IsAuthed.subscribe(status => this.changeAuthStatus(status));

   /*    this.isAuthed =  this._auth.isLoggedIn(); */

        // unsubscribe later

       this.initNavbar();
    }

    private changeAuthStatus(status: boolean): void {
      this.isAuthed = status;
  }


  initNavbar() {
    const menus = Array.from(document.querySelectorAll('.mobile-menu-toggle'));
    menus.forEach(function(btn) {
      return btn.addEventListener('click', function() {
        document.querySelector('.main-nav').classList.toggle('active');
      });
    });
  }

    logout() {
      this._auth.logout();
      // this.router.navigateByUrl('/home');
    }

}

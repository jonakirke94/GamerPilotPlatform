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

  showNav = true;
  showOverlay = false;

    constructor(private _auth: AuthService,
      private router: Router) {

       }

    ngOnInit() {
      this._auth.IsAuthed.subscribe(status => this.changeAuthStatus(status));
    }

    private changeAuthStatus(status: boolean): void {
      this.isAuthed = status;
  }

  toggleOverlay(): void {
       this.showOverlay = !this.showOverlay;
       this.showNav = !this.showNav;
     }

    // changing navbar background on scroll
    @HostListener('window:scroll', [])
    onWindowScroll() {
      if (this.showNav) {
        const myNav = document.getElementById('navbar');
        if (document.documentElement.scrollTop || document.body.scrollTop > window.innerHeight) {
          myNav.classList.add('navbarScroll');
          myNav.classList.remove('navbarTransparent');
        } else {
          myNav.classList.add('navbarTransparent');
          myNav.classList.remove('navbarScroll');
        }
      }
    }

    logout() {
      this._auth.logout();
      // this.router.navigateByUrl('/home');
    }

}

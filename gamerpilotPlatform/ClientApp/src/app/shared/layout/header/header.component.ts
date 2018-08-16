import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'layout-header',
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
    }

    private changeAuthStatus(status: boolean): void {
      this.isAuthed = status;
  }


    logout() {
      this._auth.logout();
      // this.router.navigateByUrl('/home');
    }

}

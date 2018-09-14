import { Component, OnInit} from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { Router, } from '@angular/router';

@Component({
  selector: 'app-layout-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  isAuthed: boolean;

  constructor(private _auth: AuthService,
    private router: Router) {

      }

  ngOnInit() {
    this._auth.IsAuthed$.subscribe(status => {
        this.isAuthed = status;
    });
  }


  toggle() {
    document.querySelector('.main-nav').classList.toggle('active');
  }

  logout() {
    this._auth.logout();
  }

}

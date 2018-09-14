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
  isAuthed: boolean;

  constructor(private _auth: AuthService,
    private router: Router) {

      }

  ngOnInit() {
    this._auth.IsAuthed$.subscribe(status => {
        console.log('emitted new event!');
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

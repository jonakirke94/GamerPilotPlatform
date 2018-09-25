import { Component, OnInit, OnDestroy, HostListener } from '@angular/core';

import { filter, debounceTime, takeUntil } from 'rxjs/operators';
import { Router, NavigationEnd } from '@angular/router';
import { Subject } from 'rxjs';
import { StorageService } from './core/services/storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit, OnDestroy {
  inCourseSection = false;
  private onDestroy$ = new Subject<void>();


  constructor(private _router: Router, private _storage: StorageService) {
  }

  @HostListener('window:beforeunload', ['$event'])
  clearLocalStorage(event) {
    // destroy tokens if user has not flagged the app to remember him
    if (!this._storage.rememberMe()) {
      this._storage.destroyTokens();
    }
  }

  ngOnInit() {
    this._router.events.pipe(
      filter((event) => event instanceof NavigationEnd),
      takeUntil(this.onDestroy$)
    ).subscribe(
      x =>  {
      const regex = /\/courses\/(.\/*)/g;
      const matches = regex.test(x['url']);
      this.inCourseSection = matches;
    });

  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}

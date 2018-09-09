import { Component, OnInit, OnDestroy } from '@angular/core';

import { HeaderComponent } from './shared/layout/header/header.component';
import { filter, debounceTime, takeUntil } from 'rxjs/operators';
import { Router, NavigationEnd } from '@angular/router';
import { Subject } from 'rxjs';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'app';
  inCourseSection = false;
  private onDestroy$ = new Subject<void>();


  constructor(private _router: Router) {
  }

  ngOnInit() {
    this._router.events.pipe(
      filter((event) => event instanceof NavigationEnd),
      debounceTime(1000),
      takeUntil(this.onDestroy$)
    ).subscribe(
      x => setTimeout(() => {
      const regex = /\/courses\/(.\/*)/g;
      const matches = regex.test(x['url']);
      this.inCourseSection = matches;
  }, 0));

  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}

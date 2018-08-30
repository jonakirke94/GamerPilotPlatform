import { Component, OnInit } from '@angular/core';

import { HeaderComponent } from './shared/layout/header/header.component';
import { AuthService } from './core/services/auth.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private _auth: AuthService) {
  }

  ngOnInit() {
/*     this._auth.
 */  }
}

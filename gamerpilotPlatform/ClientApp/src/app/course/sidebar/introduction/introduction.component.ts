import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../../../core/services/auth.service';
import { LockedContentComponent} from '../locked-content/locked-content.component';

@Component({
  selector: 'app-introduction',
  templateUrl: './introduction.component.html',
  styleUrls: ['./introduction.component.scss']
})
export class IntroductionComponent implements OnInit, OnDestroy {
  isLoggedIn: boolean;
  private $isLoggedObs: Subscription;

  constructor(private _auth: AuthService) { }

  ngOnInit() {
          this.isLoggedIn =  this._auth.isLoggedIn();

  }

  ngOnDestroy() {
/*     this.$isLoggedObs.unsubscribe();
 */  }
}

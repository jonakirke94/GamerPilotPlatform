import { Component} from '@angular/core';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  username = 'TestUser';
  password = '123';

  constructor(private _auth: AuthService) {


    this._auth.login(this.username, this.password).subscribe( (res) => {
      console.log(res);
      console.log('Logged in ');

    }

    );
  }
}

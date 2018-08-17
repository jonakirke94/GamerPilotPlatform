import { Component} from '@angular/core';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {


  constructor(private _auth: AuthService) {


  }
}

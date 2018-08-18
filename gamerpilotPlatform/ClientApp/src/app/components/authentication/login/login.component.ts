import { Component, OnInit, OnDestroy, ElementRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { flyInOut } from '../../../shared/animation';
import { AuthService } from '../../../core/services/auth.service';
import { RouterExtService } from '../../../shared/RouterExtService';
import {LoadingSpinnerComponent} from '../../../shared/loading-spinner/loading-spinner.component';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  animations: [flyInOut]
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  email: FormControl;
  password: FormControl;
  showSpinner = false;
  error = '';

  login$;

  constructor(
    private http: HttpClient,
    private _auth: AuthService,
    private router: Router,
    private elementRef: ElementRef,
    private routerExtService: RouterExtService,
  ) {}

  ngOnInit() {
    this.createFormControls();
    this.createForm();
  }

  ngOnDestroy() {
    // unsubscribe to prevent memory leaks
    if (this.login$ && this.login$ !== 'undefined') {
      this.login$.unsubscribe();
    }
  }

  createFormControls() {
    (this.email = new FormControl('', [
      Validators.required,
      Validators.pattern('[^ @]*@[^ *]*')
    ])),
      (this.password = new FormControl('', [
        Validators.required,
      ]));
  }

  createForm() {
    this.loginForm = new FormGroup({
      email: this.email,
      password: this.password
    });
  }

  loginUser() {
    // clear any existing data
     this._auth.logout();

    if (this.loginForm.valid) {
      const email = this.loginForm.value.email;
      const password = this.loginForm.value.password;

      // set loading to true and then false if error
      this.showSpinner = true;
      this.login$ = this._auth.login(email, password).subscribe(() => {

      // on successful auth redirect to previous url
      const previous = this.routerExtService.getPreviousUrl();

      if (previous) {
        this.router.navigateByUrl(previous);
      } else {
        this.router.navigateByUrl('/');
      }
      },
      err => {
        this.error = err.status === 400 ? 'Please check your email and password' : 'Server Error';
        this.showSpinner = false;
      });
    }

    this.loginForm.reset();
  }
}

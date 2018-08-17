import { Component, OnInit, OnDestroy, ElementRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { HttpClient } from '@angular/common/http';
import { LoadingSpinnerComponent } from '../../shared/loading-spinner/loading-spinner.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
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
    private elementRef: ElementRef
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

    // tslint:disable-next-line:use-life-cycle-interface
/*     ngAfterViewInit() {
      this.elementRef.nativeElement.querySelector('#email')
        .addEventListener('change', this.clearError);


    } */

  /*   document.getElementById('email').addEventListener('change', doThing);
   */

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

      console.log(email + password);

      // set loading to true and then false if error
      this.showSpinner = true;
      this.login$ = this._auth.login(email, password).subscribe(() => {
        /* this.router.navigateByUrl('/books'); */
      },
      err => {
        console.log(err.status);
        this.error = err.status === 400 ? 'Please check your email and password' : 'Error';
        console.log(this.error);
        this.showSpinner = false;
      });
    }

    this.loginForm.reset();
  }
}

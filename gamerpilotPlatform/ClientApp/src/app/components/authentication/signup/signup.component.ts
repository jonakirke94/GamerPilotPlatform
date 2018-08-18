import { Component, OnInit, OnDestroy, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidationErrors, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { RouterExtService } from '../../../shared/RouterExtService';
import { AuthService } from '../../../core/services/auth.service';
import { HttpClient } from '@angular/common/http';
import { flyInOut } from '../../../shared/animation';
import {LoadingSpinnerComponent} from '../../../shared/loading-spinner/loading-spinner.component';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
  animations: [flyInOut]

})
export class SignupComponent implements OnInit, OnDestroy {
  signupForm: FormGroup;
  passwords: FormGroup;
  email: FormControl;
  password: FormControl;
  confirm: FormControl;
  username: FormControl;
  showSpinner = false;
  error = '';


  login$;
  signup$;

  constructor(
    private http: HttpClient,
    private _auth: AuthService,
    private router: Router,
    private routerExtService: RouterExtService,
  ) {}

  ngOnInit() {
    this.createFormControls();
    this.createForm();
  }

  ngOnDestroy() {
  // unsubscribe to prevent memory leaks
    if (this.login$ && this.login$ !== 'undefined' && this.signup$ && this.signup$ !== 'undefined') {
      this.login$.unsubscribe();
      this.signup$.unsubscribe();
    }
  }

  createFormControls() {
    this.email = new FormControl('', [
      Validators.required,
      Validators.pattern('^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')
    ]),
      this.password = new FormControl('', [
        Validators.required,
        Validators.minLength(8)
      ]),
      this.confirm = new FormControl('', [
         Validators.required,
      ]),
      this.username = new FormControl('', [
        Validators.required,
      ]);
  }

  createForm() {
    // creating the password group first so we can assign it to a variable
    // this makes validation expressions shorter
    this.passwords = new FormGroup({
      password: this.password,
      confirm: this.confirm
    }, this.areEqual);

    this.signupForm = new FormGroup({
      username: this.username,
      email: this.email,
      passwords: this.passwords
    });
  }

  // used to determine whether the passwords match
  private areEqual(c: AbstractControl): ValidationErrors | null {
    const keys: string[] = Object.keys(c.value);
    for (const i in keys) {
      if (i !== '0' && c.value[keys[+i - 1]] !== c.value[keys[i]]) {
        return { areEqual: true };
      }
    }
  }

  signupUser() {
    if (this.signupForm.valid) {
      const username = this.signupForm.value.username;
      const email = this.signupForm.value.email;
      const password = this.passwords.value.password;

      // set loading to true and then false if error
      this.showSpinner = true;
      this.signup$ = this._auth.signup(username, email, password).subscribe(
        () => {
            // on successful auth redirect to previous url
              const previous = this.routerExtService.getPreviousUrl();
              if (previous) {
                this.router.navigateByUrl(previous);
              } else {
                this.router.navigateByUrl('/');
              }
        },
        err => {
          if (err.status === 409) {
            // 409 is sent if email wasn't unique
            this.error = err.error.value;
          } else {
            this.error = 'Server Error';
          }
          this.showSpinner = false;
        }
      );
    }
  }
}


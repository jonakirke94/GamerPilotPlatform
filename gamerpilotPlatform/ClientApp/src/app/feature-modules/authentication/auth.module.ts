import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [
      CommonModule,
      AuthRoutingModule,
      FormsModule,
      SharedModule
    ],
    declarations: [LoginComponent, SignupComponent]
  })
export class AuthModule { }

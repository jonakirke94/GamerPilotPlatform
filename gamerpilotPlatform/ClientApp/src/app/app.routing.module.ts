import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { SignupComponent } from './components/authentication/signup/signup.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { LearningbasisComponent } from './components/learningbases/learningbasis.component';
import { PrivacyPoliticsComponent } from './components/privacy-politics/privacy-politics.component';
import { TermsComponent } from './components/terms/terms.component';


const routes: Routes = [
    { path: '', component: HomeComponent }, // index
    { path: 'home', component: HomeComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'login', component: LoginComponent },
    { path: 'learningbasis', component: LearningbasisComponent },
    { path: 'privacy', component: PrivacyPoliticsComponent },
    { path: 'terms', component: TermsComponent },

    {
      path: 'courses',
      loadChildren: './course/course.module#CourseModule'
    },
    { path: '**', redirectTo: 'home' },

  ];

  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule {
  }

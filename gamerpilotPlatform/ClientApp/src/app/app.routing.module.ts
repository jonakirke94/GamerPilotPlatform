import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { LearningbasisComponent } from './components/learningbases/learningbasis.component';
import { PrivacyPoliticsComponent } from './components/privacy-politics/privacy-politics.component';
import { TermsComponent } from './components/terms/terms.component';


const routes: Routes = [
    { path: '', component: HomeComponent }, // index
    { path: 'learningbasis', component: LearningbasisComponent },
    { path: 'privacy', component: PrivacyPoliticsComponent },
    { path: 'terms', component: TermsComponent },

    {
      path: 'courses',
      loadChildren: './feature-modules/course/course.module#CourseModule'
    },
    {
      path: 'auth',
      loadChildren: './feature-modules/authentication/auth.module#AuthModule'
    },
    {
      path: 'profile',
      loadChildren: './feature-modules/profile/profile.module#ProfileModule'
    },
    {
      path: 'gamertest',
      loadChildren: './feature-modules/gamertest/gamertest.module#GamertestModule'
    },
    { path: '**', redirectTo: '' },

  ];

  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule {
  }

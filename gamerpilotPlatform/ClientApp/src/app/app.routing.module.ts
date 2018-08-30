import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BooksComponent } from './components/books/books.component';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { SignupComponent } from './components/authentication/signup/signup.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { LearningbasisComponent } from './components/learningbases/learningbasis.component';
import { CoursesComponent } from './components/courses/courses.component';
import { CourseModule } from './components/course/course.module';
import { CourseSidebarComponent } from './components/course/course-sidebar/course-sidebar.component';


const routes: Routes = [
    { path: '', component: HomeComponent }, // index
    { path: 'home', component: HomeComponent },
    { path: 'books', canActivate: [AuthGuard], component: BooksComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'login', component: LoginComponent },
    { path: 'courses', component: CoursesComponent },

    { path: 'learningbasis', component: LearningbasisComponent },

    { path: 'courses', component: CoursesComponent },

    {
      path: 'courses/:name',
      loadChildren: './course-panel/course-panel.module#CoursePanelModule'
    },
      /* children: [
        { path: '', component: CoursesComponent },
      ] */
    { path: '**', redirectTo: 'home' },

  ];

  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule {
  }

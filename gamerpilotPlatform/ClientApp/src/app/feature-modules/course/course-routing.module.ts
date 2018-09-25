import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SidebarComponent } from './sidebar/sidebar.component';
import { CoursesComponent } from './courses/courses.component';
import { LectureComponentComponent } from './lecture-component/lecture-component.component';
import { AuthGuard } from '../../core/guards/auth.guard';


const routes: Routes = [
  {
    path: '', component: CoursesComponent },
    {
    path: ':name',
    component: SidebarComponent,
    children: [
      {path: 'lectures/:id', component: LectureComponentComponent, canActivate: [AuthGuard]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }

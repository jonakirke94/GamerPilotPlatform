import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SidebarComponent } from './sidebar/sidebar.component';
import { CoursesComponent } from './courses/courses.component';
import { LectureComponentComponent } from './lecture-component/lecture-component.component';
import { AuthGuard } from '../../core/guards/auth.guard';
import { FeedbackComponent } from './feedback/feedback.component';


const routes: Routes = [
	{
		path: '', component: CoursesComponent },
		{
		path: ':name',
		component: SidebarComponent,
		children: [
			{path: 'lectures/:id', component: LectureComponentComponent, canActivate: [AuthGuard]},
			{path: 'feedback', component: FeedbackComponent, canActivate: [AuthGuard]}
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class CourseRoutingModule { }

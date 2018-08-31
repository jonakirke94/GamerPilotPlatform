import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SidebarComponent } from './sidebar/sidebar.component';
import { CoursesComponent } from './courses/courses.component';
import { IntroductionComponent } from './sidebar/introduction/introduction.component';
import { InfoComponent } from './sidebar/info/info.component';
import { CaseComponent } from './sidebar/case/case.component';
import { ProfessionalViewComponent } from './sidebar/professional-view/professional-view.component';
import { QuizComponent } from './sidebar/quiz/quiz.component';
import { ProfessionalContentComponent } from './sidebar/professional-content/professional-content.component';
import { ExercisesComponent } from './sidebar/exercises/exercises.component';
import { SummaryComponent } from './sidebar/summary/summary.component';
import { LectureComponentComponent } from './lecture-component/lecture-component.component';


const routes: Routes = [
  {
    path: '', component: CoursesComponent },
    {
    path: ':name',
    component: SidebarComponent,
    children: [
      {path: 'lectures/:id', component: LectureComponentComponent}
/*       {path: '', component: InfoComponent},
      {path: 'introduction', component: IntroductionComponent},
      {path: 'case', component: CaseComponent},
      {path: 'professional-view', component: ProfessionalViewComponent},
      {path: 'professional-content', component: ProfessionalContentComponent},
      {path: 'quiz', component: QuizComponent},
      {path: 'exercises', component: ExercisesComponent},
      {path: 'summary', component: SummaryComponent} */
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }

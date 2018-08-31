import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SidebarComponent } from './sidebar/sidebar.component';
import { IntroductionComponent } from './sidebar/introduction/introduction.component';
import { CoursesComponent } from './courses/courses.component';
import { CourseRoutingModule } from './course-routing.module';
import { InfoComponent } from './sidebar/info/info.component';
import { CaseComponent } from './sidebar/case/case.component';
import { ProfessionalViewComponent } from './sidebar/professional-view/professional-view.component';
import { QuizComponent } from './sidebar/quiz/quiz.component';
import { SummaryComponent } from './sidebar/summary/summary.component';
import { ExercisesComponent } from './sidebar/exercises/exercises.component';
import { ProfessionalContentComponent } from './sidebar/professional-content/professional-content.component';
import { LockedContentComponent } from './sidebar/locked-content/locked-content.component';
import { LectureComponentComponent } from './lecture-component/lecture-component.component';



@NgModule({
  imports: [
    CommonModule,
    CourseRoutingModule
  ],
  declarations: [SidebarComponent,
     IntroductionComponent,
      CoursesComponent, InfoComponent,
       CaseComponent, ProfessionalViewComponent,
        QuizComponent, SummaryComponent, ExercisesComponent,
         ProfessionalContentComponent, LockedContentComponent, LectureComponentComponent]
})
export class CourseModule { }

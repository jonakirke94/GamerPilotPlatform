import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SidebarComponent } from './sidebar/sidebar.component';
import { IntroductionComponent } from './sidebar/introduction/introduction.component';
import { CoursesComponent } from './courses/courses.component';
import { CourseRoutingModule } from './course-routing.module';
import { InfoComponent } from './sidebar/info/info.component';
import { CaseComponent } from './sidebar/case/case.component';
import { QuizComponent } from './sidebar/quiz/quiz.component';
import { SummaryComponent } from './sidebar/summary/summary.component';
import { ExercisesComponent } from './sidebar/exercises/exercises.component';
import { LockedContentComponent } from './sidebar/locked-content/locked-content.component';
import { LectureComponentComponent } from './lecture-component/lecture-component.component';
import { VideoComponent } from './sidebar/video/video.component';
import { StatusDirective } from './directives/status.directive';
import { IconDirective } from './directives/icon.directive';
import { TagDirective } from './directives/tag.directive';
import { SanitizeHtmlPipePipe } from './pipes/sanitize-html-pipe.pipe';
import { ExerciseTagDirective } from './directives/exercise-tag.directive';



@NgModule({
  imports: [
    CommonModule,
    CourseRoutingModule
  ],
  declarations: [SidebarComponent,
    IntroductionComponent,
    CoursesComponent, InfoComponent,
    CaseComponent,
    QuizComponent, SummaryComponent, ExercisesComponent,
    LockedContentComponent, LectureComponentComponent,
    VideoComponent, LockedContentComponent,
    StatusDirective, IconDirective, TagDirective, SanitizeHtmlPipePipe, ExerciseTagDirective]
})
export class CourseModule { }

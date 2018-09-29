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
import { SharedModule } from '../../shared/shared.module';
import { FeedbackComponent } from './feedback/feedback.component';
import { RatingStarComponent } from './helper-components/rating-star/rating-star.component';
import { NextLectureComponent } from './helper-components/next-lecture/next-lecture.component';





@NgModule({
  imports: [
    CourseRoutingModule,
    SharedModule,
  ],
  declarations: [SidebarComponent,
    IntroductionComponent,
    CoursesComponent, InfoComponent,
    CaseComponent,
    QuizComponent, SummaryComponent, ExercisesComponent,
    LockedContentComponent, LectureComponentComponent,
    VideoComponent, LockedContentComponent, FeedbackComponent, RatingStarComponent, NextLectureComponent]
})
export class CourseModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { AppRoutingModule } from '../../app.routing.module';
import { CourseSidebarComponent } from './course-sidebar/course-sidebar.component';


/* This is a feature module that contains all components for the user dashboard
   All feature modules are imported in the core module
*/
@NgModule({

    imports: [
      CommonModule,
      SharedModule,
      AppRoutingModule,

    ],
    declarations: [
        CourseSidebarComponent,
    ],
    exports: [
        CourseSidebarComponent,

    ]

  })
  export class CourseModule { }

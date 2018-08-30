import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoursePanelRoutingModule } from './course-panel-routing.module';
import { TestComponent } from './test/test.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { IntroductionComponent } from './introduction/introduction.component';


@NgModule({
  imports: [
    CommonModule,
    CoursePanelRoutingModule
  ],
  declarations: [TestComponent, SidebarComponent, IntroductionComponent]
})
export class CoursePanelModule { }

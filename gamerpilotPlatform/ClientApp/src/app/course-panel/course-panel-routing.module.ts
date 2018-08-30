import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestComponent } from './test/test.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { IntroductionComponent } from './introduction/introduction.component';

const routes: Routes = [
  {
    path: '',
    component: SidebarComponent,
    children: [
      {path: 'introduction', component: IntroductionComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoursePanelRoutingModule { }

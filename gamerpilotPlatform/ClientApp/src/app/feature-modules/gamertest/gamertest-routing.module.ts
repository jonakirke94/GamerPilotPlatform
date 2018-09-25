import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GamertestComponent } from './gamertest/gamertest.component';




const routes: Routes = [
    { path: '', component: GamertestComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GamertestRoutingModule { }

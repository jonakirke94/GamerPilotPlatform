import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { GamertestRoutingModule } from './gamertest-routing.module';
import { GamertestComponent } from './gamertest/gamertest.component';
import { TestCheckboxComponent } from './test-checkbox/test-checkbox.component';

@NgModule({
    imports: [
      CommonModule,
      GamertestRoutingModule,
    ],
    declarations: [GamertestComponent, TestCheckboxComponent,
    ]
  })
export class GamertestModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { GamertestRoutingModule } from './gamertest-routing.module';
import { GamertestComponent } from './gamertest/gamertest.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
		imports: [
			CommonModule,
			GamertestRoutingModule,
			SharedModule,
			FontAwesomeModule
		],
		declarations: [GamertestComponent,
		]
	})
export class GamertestModule { }

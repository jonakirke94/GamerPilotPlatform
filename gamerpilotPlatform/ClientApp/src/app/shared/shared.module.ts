import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';
import { RouterExtService } from './RouterExtService';
import { FooterComponent } from './layout/footer/footer.component';
import { HeaderComponent } from './layout/header/header.component';
import { CourseCarouselComponent } from './coursecarousel/coursecarousel.component';
import { TagDirective } from './directives/tag.directive';
import { ExerciseTagDirective } from './directives/exercise-tag.directive';
import { QuizDirective } from './directives/quiz.directive';

@NgModule({
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		HttpClientModule,
		RouterModule,
	],
	declarations: [
	LoadingSpinnerComponent,
	HeaderComponent,
	CourseCarouselComponent,
	FooterComponent, TagDirective, ExerciseTagDirective, QuizDirective],
	exports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		HttpClientModule,
		RouterModule,
		LoadingSpinnerComponent,
		HeaderComponent,
		CourseCarouselComponent,
		FooterComponent, TagDirective, ExerciseTagDirective, QuizDirective

	],
	providers: [
		RouterExtService,
	],
	})
export class SharedModule {}

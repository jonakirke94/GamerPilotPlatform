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
import { StatusDirective } from './directives/status.directive';
import { IconDirective } from './directives/icon.directive';
import { TagDirective } from './directives/tag.directive';
import { SanitizeHtmlPipePipe } from './pipes/sanitize-html-pipe.pipe';
import { ExerciseTagDirective } from './directives/exercise-tag.directive';



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
  FooterComponent, StatusDirective, IconDirective, TagDirective, SanitizeHtmlPipePipe, ExerciseTagDirective],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    LoadingSpinnerComponent,
    HeaderComponent,
    CourseCarouselComponent,
    FooterComponent, StatusDirective, IconDirective, TagDirective, SanitizeHtmlPipePipe, ExerciseTagDirective

  ],
  providers: [
    RouterExtService,
  ],
})
export class SharedModule {}

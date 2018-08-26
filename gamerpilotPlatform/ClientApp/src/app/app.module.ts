import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { CoreModule } from './core/core.module';
import { BooksComponent } from './components/books/books.component';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from './app.routing.module';
import { SharedModule } from './shared/shared.module';
import { RouterExtService } from './shared/RouterExtService';
import { LearningbasisComponent } from './components/learningbases/learningbasis.component';
import { CoursesComponent } from './components/courses/courses.component';

@NgModule({
  declarations: [
      AppComponent,
      HomeComponent,
      BooksComponent,
      LearningbasisComponent,
      CoursesComponent,
  ],
  imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      CommonModule,
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      CoreModule,
      BrowserAnimationsModule,
      SharedModule
  ],
   providers: [

   ],
   exports: [
   ],
   bootstrap: [AppComponent]

})
export class AppModule {
    constructor(private routerExtService: RouterExtService) {}

}



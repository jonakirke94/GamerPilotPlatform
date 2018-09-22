import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from './app.routing.module';
import { SharedModule } from './shared/shared.module';
import { RouterExtService } from './shared/RouterExtService';
import { LearningbasisComponent } from './components/learningbases/learningbasis.component';
import {SnotifyModule, SnotifyService, ToastDefaults} from 'ng-snotify';
import { TermsComponent } from './components/terms/terms.component';
import { PrivacyPoliticsComponent } from './components/privacy-politics/privacy-politics.component';
import { ProfileComponent } from './components/profile/profile.component';
import { GamertestComponent } from './components/gamertest/gamertest.component';

@NgModule({
  declarations: [
      AppComponent,
      HomeComponent,
      LearningbasisComponent,
      PrivacyPoliticsComponent,
      TermsComponent,
      ProfileComponent,
      GamertestComponent,
  ],
  imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      CommonModule,
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      CoreModule,
      BrowserAnimationsModule,
      SharedModule,
      SnotifyModule
  ],
   providers: [
    { provide: 'SnotifyToastConfig', useValue: ToastDefaults},
    SnotifyService   ],
   exports: [
   ],
   bootstrap: [AppComponent]

})
export class AppModule {
    constructor(private routerExtService: RouterExtService) {}

}



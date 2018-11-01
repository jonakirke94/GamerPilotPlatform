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

/* Icons  */
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faQuoteLeft, faCodeBranch, faChalkboardTeacher, faUserCog, faChessRook,
	faComments, faLightbulb, faPeopleCarry, faAngleDoubleRight,
	faGlobeAmericas, faAngleDoubleDown, faChild, faDiagnoses, faBoxes,
	faCircle, faAdjust, faFileAlt, faLongArrowAltRight, faLongArrowAltLeft,
	faTable, faVideo, faBrain, faFileSignature, faFlagCheckered, faArrowRight,
	faArrowLeft, faLock, faUnlock, faChevronCircleLeft, faList,
	 faDotCircle, faRocket, faTimes, faCheck } from '@fortawesome/free-solid-svg-icons';
import { faCircle as farCircle, faPlayCircle} from '@fortawesome/free-regular-svg-icons';

library.add(faTimes);
library.add(faCheck);
library.add(faRocket);
library.add(faPlayCircle);
library.add(faDotCircle);
library.add(faList);
library.add(faChevronCircleLeft);
library.add(faLock);
library.add(faUnlock);
library.add(faArrowRight);
library.add(faArrowLeft);
library.add(faTable);
library.add(faVideo);
library.add(faBrain);
library.add(faFileSignature);
library.add(faFlagCheckered);
library.add(faQuoteLeft);
library.add(faCodeBranch);
library.add(faChalkboardTeacher);
library.add(faUserCog);
library.add(faChessRook);
library.add(faComments);
library.add(faLightbulb);
library.add(faPeopleCarry);
library.add(faAngleDoubleRight);
library.add(faGlobeAmericas);
library.add(faAngleDoubleDown);
library.add(faChild);
library.add(faDiagnoses);
library.add(faBoxes);
library.add(faCircle);
library.add(faAdjust);
library.add(farCircle);
library.add(faFileAlt);
library.add(faLongArrowAltRight);
library.add(faLongArrowAltLeft);


@NgModule({
	declarations: [
			AppComponent,
			HomeComponent,
			LearningbasisComponent,
			PrivacyPoliticsComponent,
			TermsComponent,
	],
	imports: [
			BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
			AppRoutingModule,
			CoreModule,
			BrowserAnimationsModule,
			SharedModule,
			SnotifyModule,
			FontAwesomeModule
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



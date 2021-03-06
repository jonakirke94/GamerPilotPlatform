import { NgModule } from '@angular/core';
/* Icons  */
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faQuoteLeft, faCodeBranch, faChalkboardTeacher, faUserCog, faChessRook,
	faComments, faLightbulb, faPeopleCarry, faAngleDoubleRight,
	faGlobeAmericas, faAngleDoubleDown, faChild, faDiagnoses, faBoxes,
	faCircle, faAdjust, faFileAlt, faLongArrowAltRight, faLongArrowAltLeft,
	faTable, faVideo, faBrain, faFileSignature, faFlagCheckered, faArrowRight,
	faArrowLeft, faLock, faUnlock, faChevronCircleLeft, faList,
	faDotCircle, faRocket, faTimes, faCheck, faAngleDown, faFistRaised,
	faHandPointRight, faExclamationCircle, faProjectDiagram } from '@fortawesome/free-solid-svg-icons';
import { faCircle as farCircle, faPlayCircle} from '@fortawesome/free-regular-svg-icons';

library.add(faProjectDiagram);
library.add(faExclamationCircle);
library.add(faHandPointRight);
library.add(faFistRaised);
library.add(faAngleDown);
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
	imports: [
		FontAwesomeModule
	],
	exports: [
		FontAwesomeModule
	],
})
export class IconModule {}

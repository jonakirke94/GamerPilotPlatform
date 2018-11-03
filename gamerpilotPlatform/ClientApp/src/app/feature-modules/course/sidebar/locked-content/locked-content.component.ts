import { Component, EventEmitter, Output } from '@angular/core';

@Component({
	selector: 'app-locked-content',
	templateUrl: './locked-content.component.html',
	styleUrls: ['./locked-content.component.scss']
})
export class LockedContentComponent {
	@Output() enrolled = new EventEmitter<boolean>();

	constructor() { }

	enroll() {
		this.enrolled.emit(true);
	}

}

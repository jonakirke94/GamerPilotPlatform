import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'app-completed-course',
	templateUrl: './completed-course.component.html',
	styleUrls: ['./completed-course.component.scss']
})
export class CompletedCourseComponent {
	@Input() url;
	@Input() hasFeedback;
	@Output() firstClicked = new EventEmitter<boolean>();

	constructor(private _router: Router) { }

	goToFeedback() {
		this._router.navigateByUrl(`courses/${this.url}/feedback`);
	}

	first() {
		this.firstClicked.next(true);
	}

}

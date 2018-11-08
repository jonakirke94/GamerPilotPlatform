import { Component, OnInit, Input, OnChanges } from '@angular/core';

@Component({
	selector: 'app-status',
	templateUrl: './status.component.html',
	styleUrls: ['./status.component.scss']
})
export class StatusComponent implements OnChanges {
	@Input() completed;
	@Input() current;
	icon = '';
	prefix = '';
	constructor() { }

	ngOnChanges() {

		if (this.completed && !this.current) {
			this.icon = 'circle';
			this.prefix = 'fas';
		} else if (this.current) {
			this.icon = 'adjust';
			this.prefix = 'fas';
		} else {
			this.icon = 'circle';
			this.prefix = 'far';
		}

	}

}

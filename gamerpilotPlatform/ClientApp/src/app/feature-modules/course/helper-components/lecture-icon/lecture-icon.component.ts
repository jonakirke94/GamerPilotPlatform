import { Component, OnInit, Input } from '@angular/core';

@Component({
	selector: 'app-lecture-icon',
	templateUrl: './lecture-icon.component.html',
	styleUrls: ['./lecture-icon.component.scss']
})
export class LectureIconComponent implements OnInit {
	@Input() type;
	icon = '';

	constructor() {
	}

ngOnInit() {
	switch (this.type) {
		case 1:
		this.icon = 'lightbulb';
		break;
		case 2:
		this.icon = 'table';
		break;
		case 3:
		this.icon = 'file-alt';
		break;
		case 4:
		this.icon = 'video';
		break;
		case 5:
		this.icon = 'brain';
		break;
		case 6:
		this.icon = 'file-signature';
		break;
		case 7:
		this.icon = 'flag-checkered';
		break;
	}
}

}

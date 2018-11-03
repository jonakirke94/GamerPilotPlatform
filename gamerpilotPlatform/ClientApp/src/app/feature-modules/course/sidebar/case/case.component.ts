import { Component, Input, OnInit } from '@angular/core';
import { flyInOut } from '../../../../shared/animation';

@Component({
	selector: 'app-case',
	templateUrl: './case.component.html',
	styleUrls: ['./case.component.scss'],
	animations: [flyInOut]

})
export class CaseComponent implements OnInit {
	@Input() lecture;
	sections: any;
	summary: any;

	constructor() { }

	ngOnInit() {
		this.sections = this.lecture.sections.filter(x => x.title !== 'Summary');
		this.summary = this.lecture.sections.find(x => x.title === 'Summary');
	}

}

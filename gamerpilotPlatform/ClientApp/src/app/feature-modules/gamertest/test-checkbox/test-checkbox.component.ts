import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
	selector: 'app-test-checkbox',
	templateUrl: './test-checkbox.component.html',
	styleUrls: ['./test-checkbox.component.scss']
})
export class TestCheckboxComponent {
	@Input() value: number;
	@Input() label: string;
	@Input() name: string;
	@Output() change = new EventEmitter();
	constructor() { }

	setCheckbox() {
		this.change.emit(this.value);
	}

}

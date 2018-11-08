import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'app-gamertest',
	templateUrl: './gamertest.component.html',
	styleUrls: ['./gamertest.component.scss']
})
export class GamertestComponent implements OnInit {

constructor() { }

	ngOnInit() {
	}

	setValue(event) {
		console.log(event);
	}

}

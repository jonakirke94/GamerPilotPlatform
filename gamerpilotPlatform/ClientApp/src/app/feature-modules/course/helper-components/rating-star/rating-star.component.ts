import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
	selector: 'app-rating-star',
	templateUrl: './rating-star.component.html',
	styleUrls: ['./rating-star.component.scss']
})
export class RatingStarComponent {

	constructor() { }

	@Input() rating: number;
	@Input() maxStars: number;
	@Output() ratingClick: EventEmitter<any> = new EventEmitter<any>();

	onClick(rating: number): void {
		this.rating = rating;
		this.ratingClick.emit(rating);
	}
}

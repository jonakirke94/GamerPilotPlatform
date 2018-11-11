import { Directive, Input, ElementRef, OnChanges } from '@angular/core';

@Directive({
	selector: '[appProgress]'
})
export class ProgressDirective implements OnChanges {
	@Input() width;

	constructor(private el: ElementRef) {}

	ngOnChanges() {
		this.el.nativeElement.style.width = this.width + '%';
		this.el.nativeElement.style.maxWidth = this.width + '%';
	}

}

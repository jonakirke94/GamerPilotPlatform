import { Directive, ElementRef, Input, OnInit, OnChanges } from '@angular/core';

@Directive({
  selector: '[appStatus]'
})
export class StatusDirective implements OnChanges {
  @Input() completed;
  @Input() current;

  constructor(private el: ElementRef) {
  }

  ngOnChanges() {
    if (this.completed && !this.current) {
      this.el.nativeElement.classList.add('fas', 'fa-circle');
    } else if (this.current) {
      this.el.nativeElement.classList.add('fas', 'fa-adjust');
    } else {
      this.el.nativeElement.classList.add('far', 'fa-circle');
    }

  }

}

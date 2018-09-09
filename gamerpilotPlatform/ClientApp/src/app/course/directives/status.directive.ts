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
      this.el.nativeElement.style.backgroundColor = 'green';
    } else if (this.current) {
      this.el.nativeElement.style.backgroundColor = 'yellow';
    } else {
      this.el.nativeElement.style.backgroundColor = 'red';
    }

  }

}

import { Directive, Input, ElementRef, OnInit } from '@angular/core';

@Directive({
  selector: '[appTag]'
})
export class TagDirective implements OnInit {
  @Input() difficulty: string;

  constructor(private el: ElementRef) {

  }

  ngOnInit() {
    if (this.difficulty === 'easy') {
        this.el.nativeElement.classList.add('easy');
    } else if (this.difficulty === 'medium') {
        this.el.nativeElement.classList.add('medium');
    } else {
      this.el.nativeElement.classList.add('hard');
    }
  }

}

import { Directive, Input, OnInit, ElementRef } from '@angular/core';

@Directive({
  selector: '[appExerciseTag]'
})
export class ExerciseTagDirective implements OnInit {
  @Input() location: boolean;

  constructor(private el: ElementRef) {

  }

  ngOnInit() {
    this.location ? this.el.nativeElement.classList.add('real-life') : this.el.nativeElement.classList.add('ingame');
  }
}

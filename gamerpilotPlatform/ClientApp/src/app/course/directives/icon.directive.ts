import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appIcon]'
})
export class IconDirective implements OnInit {
  @Input() type;

  constructor(private el: ElementRef) {
  }

  ngOnInit() {
      switch (this.type) {
        case 1:
        this.el.nativeElement.classList.add('fas', 'fa-lightbulb');
        break;
        case 2:
        this.el.nativeElement.classList.add('fas', 'fa-table');
        break;
        case 3:
        this.el.nativeElement.classList.add('fas', 'fa-file-alt');
        break;
        case 4:
        this.el.nativeElement.classList.add('fas', 'fa-video');
        break;
        case 5:
        this.el.nativeElement.classList.add('fas', 'fa-brain');
        break;
        case 6:
        this.el.nativeElement.classList.add('fas', 'fa-file-signature');
        break;
        case 7:
        this.el.nativeElement.classList.add('fas', 'fa-flag-checkered');
        break;
      }
  }
}


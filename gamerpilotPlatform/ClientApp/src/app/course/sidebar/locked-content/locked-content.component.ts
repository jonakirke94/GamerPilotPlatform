import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-locked-content',
  templateUrl: './locked-content.component.html',
  styleUrls: ['./locked-content.component.scss']
})
export class LockedContentComponent implements OnInit {
  @Output() enrolled = new EventEmitter<boolean>();
  clicked = false;

  constructor() { }

  ngOnInit() {
  }

  enroll() {
    this.enrolled.emit(true);
    this.clicked = true;
  }

}

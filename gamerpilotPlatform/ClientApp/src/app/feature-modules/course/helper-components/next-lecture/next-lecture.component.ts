import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-next-lecture',
  templateUrl: './next-lecture.component.html',
  styleUrls: ['./next-lecture.component.scss']
})
export class NextLectureComponent implements OnInit {
  @Output() nextClicked = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit() {
  }

  next() {
    this.nextClicked.emit(true);
  }
}

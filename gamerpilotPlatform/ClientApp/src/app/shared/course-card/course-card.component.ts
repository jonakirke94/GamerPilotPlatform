import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.scss']
})
export class CourseCardComponent implements OnInit {
  @Input()  course: any;
  @Output() viewcourse = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
  }

  showCourse(soon: boolean, id: string) {
    if (!soon) {
      console.log('Clicked on available course');
      this.viewcourse.emit(id);
    } else {
      console.log('Clicked on NOT available');
    }
  }

}

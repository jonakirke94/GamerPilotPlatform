import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-exercises',
  templateUrl: './exercises.component.html',
  styleUrls: ['./exercises.component.scss']
})
export class ExercisesComponent implements OnInit {
@Input() lecture;
  constructor() { }

  ngOnInit() {
    console.log(this.lecture);
  }

}

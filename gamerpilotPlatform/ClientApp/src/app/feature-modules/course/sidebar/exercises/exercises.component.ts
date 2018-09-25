import { Component, Input } from '@angular/core';
import { listAnimationSlow } from '../../../../shared/animation';

@Component({
  selector: 'app-exercises',
  templateUrl: './exercises.component.html',
  styleUrls: ['./exercises.component.scss'],
  animations: [listAnimationSlow]

})
export class ExercisesComponent {
@Input() lecture;
  constructor() { }


}

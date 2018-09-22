import { Component, Input } from '@angular/core';
import { flyInOut } from '../../../shared/animation';


@Component({
  selector: 'app-introduction',
  templateUrl: './introduction.component.html',
  styleUrls: ['./introduction.component.scss'],
  animations: [flyInOut]

})
export class IntroductionComponent {
  @Input() lecture;

  constructor() { }

}

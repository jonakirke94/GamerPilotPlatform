import { Component, Input } from '@angular/core';
import { flyInOut } from '../../../shared/animation';


@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss'],
  animations: [flyInOut]

})
export class InfoComponent {
  @Input() lecture;

  constructor() { }
}

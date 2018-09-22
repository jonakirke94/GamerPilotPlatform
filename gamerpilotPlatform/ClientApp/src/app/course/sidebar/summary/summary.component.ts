import { Component, Input } from '@angular/core';
import { flyInOut } from '../../../shared/animation';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.scss'],
  animations: [flyInOut]

})
export class SummaryComponent {
@Input() lecture;
  constructor() { }

}

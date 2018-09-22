import { Component, Input } from '@angular/core';
import { flyInOut } from '../../../shared/animation';

@Component({
  selector: 'app-case',
  templateUrl: './case.component.html',
  styleUrls: ['./case.component.scss'],
  animations: [flyInOut]

})
export class CaseComponent {
  @Input() lecture;

  constructor() { }

}

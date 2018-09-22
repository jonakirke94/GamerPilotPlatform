import { Component, OnInit } from '@angular/core';
import { flyInOut } from '../../shared/animation';

@Component({
  selector: 'app-learningbasis',
  templateUrl: './learningbasis.component.html',
  styleUrls: ['./learningbasis.component.scss'],
  animations: [flyInOut]

})
export class LearningbasisComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

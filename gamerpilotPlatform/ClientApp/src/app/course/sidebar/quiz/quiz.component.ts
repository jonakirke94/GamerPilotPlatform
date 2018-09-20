import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent {
  @Input() lecture;

  constructor() { }

  toggle(event) {
    const container = event.currentTarget.parentElement;
    container.querySelector('.answer').classList.toggle('hidden');
    container.querySelector('button i').classList.toggle('fa-rotate-180');
  }

}

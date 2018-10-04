import { Component, Input, OnInit } from '@angular/core';
import { listAnimationSlow } from '../../../../shared/animation';
import { Question } from '../../../../../models/question';
import { Choice } from '../../../../../models/choice';
import {LoadingSpinnerComponent} from '../../../../shared/loading-spinner/loading-spinner.component';
import { QuizService } from '../../../../core/services/quiz.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss'],
  animations: [listAnimationSlow]

})
export class QuizComponent implements OnInit {
  @Input() lecture;
  @Input() url: string;

  currentQuestion: Question;
  questions: Question[] = [];

  currentIndex = 0;
  userAnswers: string[] = [];
  attempts: any;
  bar: HTMLElement;
  results: {question: Question, choice: Choice}[] = [];

  showResult = false;
  loading = false;
  selectedAttemptIndex: number;

  constructor(private _quizService: QuizService) {
  }

  ngOnInit() {
    this.questions = this.lecture.questions;
    this.currentQuestion = this.questions[0];
    this.bar = document.querySelector('.progress-bar');


    this.fetchAttempts();
  }

  fetchAttempts() {
    this._quizService.getAttempts(this.url).subscribe(res => {
      this.attempts = res;
      console.log(res);
    });
  }

  selectChoice(choice: Choice) {
    this.userAnswers.push(choice.id);
    this.next();
  }

  next() {
    const nextIndex = this.currentIndex + 1;
    if (nextIndex < this.questions.length) {
      const progress = ((this.questions.indexOf(this.currentQuestion) + 1) / (this.questions.length)) * 100 + '%';
      this.setProgress(progress);
      this.currentIndex++;
      this.currentQuestion = this.questions[nextIndex];

    } else if (nextIndex === this.questions.length) {
      this.complete();
    }
  }

  setProgress(progress: string) {
    this.bar.style.width = progress;
    this.bar.style.maxWidth = progress;
  }

  complete() {
    this.loading = true;
    this.showAnswers(this.userAnswers, false);

    this._quizService.submitAnswers(this.userAnswers, this.url).subscribe( () => {

      this.fetchAttempts();

      this.loading = false;
      this.setProgress('100%');
    });

  }

  tryAgain() {
    this.showResult = false;
    this.userAnswers = [];
    this.currentIndex = 0;
    this.setProgress('0%');
  }

  showAnswers(answers: any[], fromServer: boolean, selectedIndex: number = this.attempts.length) {
    // make sure results are resest
    this.results = [];

    // highlight previous attempt link
    this.selectedAttemptIndex = selectedIndex;

    if (fromServer) {
      answers = answers.map(x => x.userChoiceId);
    }
    this.showResult = true;
     for (let index = 0; index < this.questions.length; index++) {
       const choice = this.questions[index].choices.find(x => x.id === answers[index]);
       this.results.push({
         question: this.questions[index],
         choice,
       });
     }

    this.setProgress('100%');
  }
}

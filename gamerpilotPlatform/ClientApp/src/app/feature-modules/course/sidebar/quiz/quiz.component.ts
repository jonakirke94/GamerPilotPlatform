import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { listAnimationSlow } from '../../../../shared/animation';
import { Question } from '../../../../../models/question';
import { Choice } from '../../../../../models/quiz/choice';
import {LoadingSpinnerComponent} from '../../../../shared/loading-spinner/loading-spinner.component';
import { QuizService } from '../../../../core/services/quiz.service';
import { ActivatedRoute } from '@angular/router';
import { Attempt } from '../../../../../models/quiz/attempt';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
	selector: 'app-quiz',
	templateUrl: './quiz.component.html',
	styleUrls: ['./quiz.component.scss'],
})
export class QuizComponent implements OnInit, OnDestroy {
	private onDestroy$ = new Subject<void>();

	@Input() lecture;
	@Input() url: string;

	currentQuestion: Question;
	questions: Question[] = [];

	currentIndex = 0;
	userAnswers: string[] = [];
	attempts: Attempt[] = [];
	results: {question: Question, choice: Choice}[] = [];
	progress = 0;

	showResult = false;
	loading = false;
	selectedAttemptIndex: number;

	constructor(private _quizService: QuizService) {
	}

	ngOnInit() {
		this.questions = this.lecture.questions;
		this.currentQuestion = this.questions[0];

		this.fetchAttempts();
	}

	fetchAttempts() {
		this._quizService.getAttempts(this.url)
		.pipe(takeUntil(this.onDestroy$))
		.subscribe(res => {
			this.attempts = res as Attempt[];
			this.attempts.reverse();
		});
	}

	selectChoice(choice: Choice) {
		this.userAnswers.push(choice.id);
		this.next();
	}

	next() {
		const nextIndex = this.currentIndex + 1;
		if (nextIndex < this.questions.length) {
			const currProgress = ((this.questions.indexOf(this.currentQuestion) + 1) / (this.questions.length)) * 100 ;
			this.progress = currProgress;
			this.currentIndex++;
			this.currentQuestion = this.questions[nextIndex];

		} else if (nextIndex === this.questions.length) {
			this.complete();
		}
	}

	complete() {
		this.loading = true;
		this.showAnswers(this.userAnswers, false);

		this._quizService.submitAnswers(this.userAnswers, this.url)
		.pipe(takeUntil(this.onDestroy$))
		.subscribe( () => {

			this.fetchAttempts();

			this.loading = false;
			this.progress = 100;
		});

	}

	tryAgain() {
		this.showResult = false;
		this.userAnswers = [];
		this.currentIndex = 0;
		this.currentQuestion = this.questions[0];
		this.progress = 0;
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

		this.progress = 100;
	}

	ngOnDestroy() {
		this.onDestroy$.next();
		this.onDestroy$.complete();
	}
}

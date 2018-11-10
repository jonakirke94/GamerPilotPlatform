import { Component, OnInit, OnDestroy } from '@angular/core';
import { GamertestService } from '../../../core/services/gamertest.service';
import {LoadingSpinnerComponent} from '../../../shared/loading-spinner/loading-spinner.component';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { TestQuestion } from '../../../../models/test-question';

@Component({
	selector: 'app-gamertest',
	templateUrl: './gamertest.component.html',
	styleUrls: ['./gamertest.component.scss']
})
export class GamertestComponent implements OnInit, OnDestroy {

constructor(private _gamertestService: GamertestService) { }
	private onDestroy$ = new Subject<void>();
	currentIndex = 0;
	questions: TestQuestion[] = [];
	answers: TestQuestion[] = [];
	dataLoaded = false;
	showIntro = true;
	showResult = false;
	generatingResult = false;
	hasValue = false;
	selectedValue: number;
	buttonText = 'Next';
	result = '';
	progress = 0;

	ngOnInit() {
		this._gamertestService.fetch()
		.pipe(
			takeUntil(this.onDestroy$
		))
		.subscribe(res => {
			this.questions = res as TestQuestion[];
			this.dataLoaded = true;
		});
	}

	ngOnDestroy() {
		this.onDestroy$.next();
		this.onDestroy$.complete();
	}

	select(val) {
		this.selectedValue = val;
		this.hasValue = true;
	}

	deselectRadios() {
		const radios = (<HTMLInputElement[]><any>document.querySelectorAll('.radio'));
		radios.forEach(radio => {
			radio.checked = false;
		});

		this.hasValue = false;
	}

	next() {
		this.deselectRadios();

		this.questions[this.currentIndex].value = this.selectedValue;
		this.answers.push(this.questions[this.currentIndex]);

		const currProgress = ((this.currentIndex + 1) / this.questions.length) * 100;
		this.progress = currProgress;

		if (this.currentIndex + 1 === this.questions.length) {
			this.generateResult();
		} else {
			this.currentIndex++;

			if (this.currentIndex + 1 === this.questions.length) {
				this.buttonText = 'Get result';
			}
		}
	}

	showQuestion() {
		return this.dataLoaded && !this.showIntro && !this.generatingResult && !this.showResult;
	}

	generateResult() {
		this.generatingResult = true;
		this._gamertestService.submit(this.answers)
		.pipe(
			takeUntil(this.onDestroy$
		))
		.subscribe(res => {
			this.result = res['description'];
			this.generatingResult = false;
			this.showResult = true;
		});
	}

	start() {
		this.showIntro = false;
	}

}

import { Injectable, Inject } from '@angular/core';
import { Choice } from '../../../models/quiz/choice';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class QuizService {
	baseUrl: string;

	constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
		this.baseUrl = _baseUrl + 'api/quiz/';
	}


	submitAnswers(choices: string[], urlName: string) {
		const body = {
			choices: JSON.stringify(choices),
			urlName
		};
		return this.http
		.post(this.baseUrl + `answer`, body);
	}

	getAttempts(urlName: string) {
		return this.http
		.get(this.baseUrl + `attempts/${urlName}`);
	}
}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class GamertestService {
	baseUrl: string;

	constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
		this.baseUrl = _baseUrl + 'api/gamertest/';
	}

	submit(answers) {
		return this.http
			.post(this.baseUrl, answers);
	}

	fetch() {
		return this.http
		.get(this.baseUrl);
	}
}

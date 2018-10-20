import { Component, OnInit, OnDestroy, Input, Output } from '@angular/core';
import { Subject } from 'rxjs';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { CourseService } from '../../../core/services/course.service';
import { Feedback } from '../../../../models/feedback';
import { ActivatedRoute, Params } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import {LoadingSpinnerComponent} from '../../../shared/loading-spinner/loading-spinner.component';
import { EventEmitter } from 'protractor';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.scss']
})
export class FeedbackComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();
  showFeedback = true;

  feedbackForm: FormGroup;
  radioYoutube: FormControl;
  radioPay: FormControl;
  youtubeResponse: FormControl;
  howMuch: FormControl;
  rating = 6;
  recommendation = 6;
  courseName: string;
  showSpinner = false;
  error = '';

  constructor(
    private _courseService: CourseService,
    private _activeRoute: ActivatedRoute
    ) { }

  ngOnInit() {
    this.createFormControls();
    this.createForm();
    this.fetchUrl();



 /*    if (this.feedback) {
      this.showFeedback = false;
    } */
  }

  fetchUrl() {
    this._activeRoute.params
    .pipe(
      takeUntil(this.onDestroy$
    ))
    .subscribe((params: Params) => {
      this._activeRoute.parent.params
    .pipe(
      takeUntil(this.onDestroy$
    ))
    .subscribe((parentParams: Params) => {
        this.courseName = parentParams['name'];
        this._courseService.hasFeedback(this.courseName).pipe(
          takeUntil(this.onDestroy$
        ))
        .subscribe(res => {
          this.showFeedback = !res as boolean;
        });
      });
    });
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }

  private createFormControls() {
    this.radioYoutube = new FormControl();
    this.radioPay = new FormControl();
    this.howMuch = new FormControl();
    this.youtubeResponse = new FormControl();


  }

  private createForm() {
    this.feedbackForm = new FormGroup({
      differentFromYoutube: this.radioYoutube,
      willingToPay: this.radioPay,
      howMuch: this.howMuch,
      youtubeResponse: this.youtubeResponse
    });
  }

  ratingClick(rating: any): void {
    this.rating = rating;
  }

  recommendationClick(recommendation: any): void {
    this.recommendation = recommendation;
  }

  submitFeedback() {
      const feedback = {} as Feedback;
      feedback.Rating = this.rating;
      feedback.LikelyToRecommend = this.recommendation;
      feedback.DifferentFromYoutube = this.radioYoutube.value === 'true' ? true : false;
      feedback.WillingToPay = this.radioPay.value === 'true' ? true : false;
      feedback.HowMuch = this.howMuch.value === null ? 0 : this.howMuch.value;
      feedback.YoutubeResponse = this.youtubeResponse.value === null ? '' : this.youtubeResponse.value;
      feedback.CourseUrl = this.courseName;

      console.log(feedback, 'FEEDBBACK');

      this._courseService.saveFeedback(feedback).pipe(
        takeUntil(this.onDestroy$
      ))
      .subscribe( res => {
        this.showFeedback = false;
        this._courseService.hasFeedback$.next(true);
      }, err => {
        this.error = 'Server error';
      });
  }
}

import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Subject } from 'rxjs';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { CourseService } from '../../../core/services/course.service';
import { Feedback } from '../../../../models/feedback';
import { ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.scss']
})
export class FeedbackComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();
  @Input() feedback: Feedback;
  showFeedback = true;

  feedbackForm: FormGroup;
  q1: FormControl;
  q2: FormControl;
  rating = 6;
  recommendation = 6;
  courseName: string;
  showSpinner = false;
  error = '';

  constructor(
    private _coursService: CourseService,
    private _activeRoute: ActivatedRoute
    ) { }

  ngOnInit() {
    this.courseName = this._activeRoute.snapshot.paramMap.get('name');
    this.createFormControls();
    this.createForm();

    if (this.feedback) {
      this.showFeedback = false;
    }
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }

  private createFormControls() {
    this.q1 = new FormControl();
    this.q2 = new FormControl();

  }

  private createForm() {
    this.feedbackForm = new FormGroup({
      q1: this.q1,
      q2: this.q2
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
      feedback.rating = this.rating;
      feedback.likelyToRecommend = this.recommendation;
      feedback.uniqueCourseOpinion = this.feedbackForm.value.q1;
      feedback.wouldPayOpinion = this.feedbackForm.value.q2;
      feedback.courseUrl = this.courseName;

      this._coursService.saveFeedback(feedback).pipe(
        takeUntil(this.onDestroy$
      ))
      .subscribe( res => {
        this.showFeedback = false;
      }, err => {
        this.error = 'Server error';
      });
  }
}

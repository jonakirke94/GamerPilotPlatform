import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Subject } from 'rxjs';
import { Validators, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.scss']
})
export class FeedbackComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();
  @Input() feedback;
  showFeedback = true;

  feedbackForm: FormGroup;
  q1: FormControl;
  q2: FormControl;
  showSpinner = false;
  error = '';

  constructor() { }

  ngOnInit() {
    this.createFormControls();
    this.createForm();

    if (!!this.feedback) {
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

  ratingComponentClick(rating: any): void {
    console.log('rating:' + rating);

  }

  submitFeedback() {

    //showFeedback = false;
  }
}

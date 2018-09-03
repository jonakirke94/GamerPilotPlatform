import { Component, OnInit, OnDestroy } from '@angular/core';
import { Course } from '../../../models/course';
import { ActivatedRoute, Params } from '@angular/router';
import { CourseService } from '../../core/services/course.service';
import { Lecture } from '../../../models/lecture';
import { AuthService } from '../../core/services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-lecture-component',
  templateUrl: './lecture-component.component.html',
  styleUrls: ['./lecture-component.component.scss']
})
export class LectureComponentComponent implements OnInit, OnDestroy {
  dataLoaded = false;
  $params: Subscription;
  lecture;
  isLoggedIn = false;
  paramId: string;

  constructor(private _activeRoute: ActivatedRoute, private _courseService: CourseService, private _authService: AuthService ) { }


  ngOnInit() {
    this.$params = this._activeRoute.params.subscribe((params: Params) => {
      this.paramId = params['id'];
    });

    if (!!this.paramId) {
      this.loadLecture(this.paramId);
    }
 /*    this._authService. */
  }

  loadLecture(id: string) {
      this._courseService.getLecture(id).subscribe(res => {
        this.lecture = res['data'];
        this.dataLoaded = true;
      });
  }

  ngOnDestroy() {
    this.$params.unsubscribe();
  }
}

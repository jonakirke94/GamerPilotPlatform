import { Component, OnInit, OnDestroy } from '@angular/core';
import { Course } from '../../../models/course';
import { ActivatedRoute, Params, Router } from '@angular/router';
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

  isLoggedIn;
  isEnrolled;
  lecture;

  courseName: string;
  lectureId: string;

  $idParams: Subscription;
  $nameParams: Subscription;

  constructor(
    private _activeRoute: ActivatedRoute,
    private _courseService: CourseService,
    private _router: Router) { }


  ngOnInit() {
    this.$idParams = this._activeRoute.params.subscribe((params: Params) => {
      this.$nameParams = this._activeRoute.parent.params.subscribe((parentParams: Params) => {
        this.courseName = parentParams['name'];
        this.lectureId = params['id'];

          this.loadLecture(this.courseName, this.lectureId);
      });
    });
  }

  loadLecture(name: string, id: string) {
      this._courseService.getLecture(name, id).subscribe(res => {
        this.lecture = res['data'];
        this.dataLoaded = true;
      },
      err => {
        // if user was not enrolled
        if (err.status = 400) {
          this._router.navigateByUrl(`/courses/${this.courseName}`);
        }
      });
  }

  ngOnDestroy() {
    this.$idParams.unsubscribe();
    this.$nameParams.unsubscribe();
  }
}

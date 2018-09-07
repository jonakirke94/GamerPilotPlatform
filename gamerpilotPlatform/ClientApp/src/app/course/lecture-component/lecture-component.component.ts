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
  $idParams: Subscription;
  $nameParams: Subscription;
  lecture;
  isLoggedIn = false;

  constructor(private _activeRoute: ActivatedRoute, private _courseService: CourseService, private _authService: AuthService ) { }


  ngOnInit() {
    this.$idParams = this._activeRoute.params.subscribe((params: Params) => {

      this.$nameParams = this._activeRoute.parent.params.subscribe((parentParams: Params) => {
          this.loadLecture(parentParams['name'], params['id']);
      });
    });

    console.log(this._activeRoute.url, 'url');

  }

  loadLecture(name: string, id: string) {
      this._courseService.getLecture(name, id).subscribe(res => {
        this.lecture = res['data'];
        this.dataLoaded = true;
      });
  }

  ngOnDestroy() {
    this.$idParams.unsubscribe();
    this.$nameParams.unsubscribe();
  }
}

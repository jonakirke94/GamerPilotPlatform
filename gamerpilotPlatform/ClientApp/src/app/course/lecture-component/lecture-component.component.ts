import { Component, OnInit } from '@angular/core';
import { Course } from '../../../models/course';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../../core/services/course.service';
import { Lecture } from '../../../models/lecture';
import { InfoComponent} from '../sidebar/info/info.component';

@Component({
  selector: 'app-lecture-component',
  templateUrl: './lecture-component.component.html',
  styleUrls: ['./lecture-component.component.scss']
})
export class LectureComponentComponent implements OnInit {
  dataLoaded = false;
  lecture;

  constructor(private _activeRoute: ActivatedRoute, private _courseService: CourseService ) { }

  ngOnInit() {
    const idParam: string = this._activeRoute.snapshot.paramMap.get('id');

    this.loadLecture(idParam);
    // retrieve route and check if the course exists
  }

  loadLecture(id: string) {
      this._courseService.getLecture(id).subscribe(res => {
        console.log(res, 'lecture in lecturecomp');
        this.lecture = res['data'];

        this.dataLoaded = true;
      });
  }
}

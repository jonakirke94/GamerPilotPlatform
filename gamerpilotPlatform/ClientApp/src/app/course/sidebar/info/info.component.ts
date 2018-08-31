import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../../../core/services/course.service';
import { Course } from '../../../../models/course';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent implements OnInit {
  @Input() lecture;

  constructor() { }

  ngOnInit() {

  }




}

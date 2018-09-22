import { Component, OnInit, Output, Input, EventEmitter, OnDestroy } from '@angular/core';
import { CourseService } from '../../core/services/course.service';
import { Subscription, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';

declare var $: any;

@Component({
  selector: 'app-coursecarousel',
  templateUrl: './coursecarousel.component.html',
  styleUrls: ['./coursecarousel.component.scss']
})
export class CourseCarouselComponent implements OnInit, OnDestroy {
  private onDestroy$ = new Subject<void>();
  courses: any = [];
  $courses: Subscription;
  carouselItems: any = [];
  isDataLoaded = false;

  constructor(private _courseService: CourseService, private _router: Router) { }

  ngOnInit() {
    this.fetchCourses();
    this.buildCarousel();
  }

  buildCarousel() {
    $('#carouselExample').on('slide.bs.carousel', function (e) {
      const $e = $(e.relatedTarget);
      const idx = $e.index();
      const itemsPerSlide = 4;
      const totalItems = $('.carousel-item').length;
      if (idx >= totalItems - (itemsPerSlide - 1)) {
        const it = itemsPerSlide - (totalItems - idx);
          for (let i = 0; i < it; i++) {
              if (e.direction === 'left') {
                  $('.carousel-item').eq(i).appendTo('.carousel-inner');
              } else {
                  $('.carousel-item').eq(0).appendTo('.carousel-inner');
              }
          }
      }
    });
    $('#carouselExample').carousel( {
              interval: 2000,
    });
  }

  fetchCourses() {
    this.$courses = this._courseService.getCourses()
    .pipe(
      takeUntil(this.onDestroy$
    ))
    .subscribe(res => {
      this.courses = res['data'] as Array<any>;
      this.courses.concat(res['data'] as Array<any>);
      this.courses.concat(res['data'] as Array<any>);
      this.courses.concat(res['data'] as Array<any>);
      this.isDataLoaded = true;
    });
  }

  goToCourse(url: string, isReleased: boolean) {
      if (isReleased) {
        this._router.navigateByUrl(`/courses${url}`);
      }
  }

  ngOnDestroy() {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }

  }

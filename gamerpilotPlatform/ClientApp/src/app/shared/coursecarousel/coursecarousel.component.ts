import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { CourseService } from '../../core/services/course.service';

declare var $: any;

@Component({
  selector: 'app-coursecarousel',
  templateUrl: './coursecarousel.component.html',
  styleUrls: ['./coursecarousel.component.scss']
})
export class CourseCarouselComponent implements OnInit {
  @Input()  course: any;
  @Output() viewcourse = new EventEmitter<string>();
  courses: any = [];
  carouselItems: any = [];
  constructor(private _courseService: CourseService) { }

     ngOnInit() {
      this.courses = this._courseService.getCourses();

      this.carouselItems = this.courses;
      this.carouselItems.shift();

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
                interval: 3000,
            });
    }

    showCourse(soon: boolean, id: string) {
      if (!soon) {
        console.log('Clicked on available course');
        this.viewcourse.emit(id);
      } else {
        console.log('Clicked on NOT available');
      }
    }

  }

import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

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
  constructor() { }

     ngOnInit() {
      this.courses.push({
        topic: 'Communication',
        imgUrl: 'https://picsum.photos/600/600?random',
        fa: 'fas fa-headset',
        soon: false,
        id: 1,
      });

      this.courses.push({
        topic: 'Strategy',
        imgUrl: 'https://picsum.photos/600/600/?random',
        fa: 'fab fa-accessible-icon',
        soon: false,
        id: 2,
      });

      this.courses.push({
        topic: 'Teamwork',
        imgUrl: 'https://picsum.photos/600/600?random',
        fa: 'fas fa-allergies',
        soon: false,
        id: 3,
      });

      this.courses.push({
        topic: 'Concentration',
        imgUrl: 'https://picsum.photos/600/600?random',
        fa: 'fas fa-address-book',
        soon: false,
        id: 4,
      });

      this.courses.push({
        topic: 'Concentration111',
        imgUrl: 'https://picsum.photos/600/600?random',
        fa: 'fas fa-address-book',
        soon: false,
        id: 5,
      });


      this.courses.push({
        topic: 'Concentration111',
        imgUrl: 'https://picsum.photos/600/600?random',
        fa: 'fas fa-address-book',
        soon: true,
        id: 6,
      });

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
                interval: 5000,
                ride: true
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

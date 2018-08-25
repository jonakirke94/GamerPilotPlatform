import { Component, OnInit, Input, HostListener } from '@angular/core';
import * as $ from 'jquery';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']

})

export class HomeComponent {
  public fixed = false;


  constructor() {

  }

  ngOnInit() {
    $('#carouselExample').on('slide.bs.carousel', function (e) {
      const $e = $(e.relatedTarget);
      console.log($e);
      const idx = $e.index();
      const itemsPerSlide = 4;
      const totalItems = $('.carousel-item').length;
      if (idx >= totalItems - (itemsPerSlide - 1)) {
        const it = itemsPerSlide - (totalItems - idx);
          for (let i = 0; i < it; i++) {
              // append slides to end
              if (e.direction === 'left') {
                  $('.carousel-item').eq(i).appendTo('.carousel-inner');
              } else {
                  $('.carousel-item').eq(0).appendTo('.carousel-inner');
              }
          }
      }
    });
        $('#carouselExample').carousel( {interval: 2000
              });


        /* show lightbox when clicking a thumbnail */
          $('a.thumb').click(function(event) {
            event.preventDefault();
            const content = $('.modal-body');
            content.empty();
            const title = $(this).attr('title');
              $('.modal-title').html(title);
              content.html($(this).html());
              $('.modal-profile').modal({show: true});
          });
  }

   // tslint:disable-next-line:use-life-cycle-interface
    @HostListener('window:scroll', [])
    onWindowScroll() {
      const nav: HTMLElement = document.querySelector('.features-nav');
      const sticky = nav.offsetTop;
      const navHeight = nav.offsetHeight;
      if (window.pageYOffset > sticky) {
        document.body.style.paddingTop = (navHeight + 16) + 'px';
        this.fixed = true;
        // header.classList.add("fixed-nav");
      } else {
        document.body.style.paddingTop = '0';
        this.fixed = false;
        // header.classList.remove("fixed-nav");
      }

      const sec1: HTMLElement = document.querySelector('#section-1');
      const sec2: HTMLElement = document.querySelector('#section-2');
      const sec3: HTMLElement = document.querySelector('#section-3');
      const sec2Top = sec2.offsetTop;
      const sec3Top = sec3.offsetTop;

      // Lavalamp animation
    if ((window.scrollY + navHeight + 50) >= sec2Top && (window.scrollY + navHeight) < sec3Top) {
      this.removeActiveClass();
      document.querySelector('.section-2-link').classList.add('active');
      this.lavalampBar();
    } else if ((window.scrollY + navHeight) >= sec3Top) {
      this.removeActiveClass();
      document.querySelector('.section-3-link').classList.add('active');
      this.lavalampBar();
    } else {
      this.removeActiveClass();
      document.querySelector('.section-1-link').classList.add('active');
      this.lavalampBar();


    }


  }

  removeActiveClass() {
    document.querySelectorAll('.features-nav-link').forEach(function (el) {
      el.classList.remove('active');
    });
  }

  lavalampBar() {
    const activeItem: HTMLElement = document.querySelector('.active.features-nav-link');
    const lavalampElm: HTMLElement = document.querySelector('.lavalamp');
    const positionLavalamp = function (activeElm) {
      lavalampElm.style.width = activeElm.offsetWidth + 'px';
      lavalampElm.style.left = activeElm.offsetLeft + 'px';
    };
    positionLavalamp(activeItem);
    window.addEventListener('resize', function () {
     positionLavalamp(activeItem);
    });
  }

  scrollToElement($element): void {
    $element.scrollIntoView({behavior: 'smooth', block: 'start'});
    $element.scrollTop += 30;

  }

  /* carousel */

}

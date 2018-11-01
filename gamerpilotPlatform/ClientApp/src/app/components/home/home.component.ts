import { Component, OnInit, HostListener, Inject, OnDestroy} from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']

})

export class HomeComponent implements OnInit, OnDestroy {
  public fixed = false;
  nav: HTMLElement;
  navOffsetTop;
  navHeight;
  courseTop;

  constructor(@Inject(DOCUMENT) document, private _router: Router) {
  }

  ngOnInit() {
    this.setNavFields();
  }

  setNavFields() {
    this.nav = document.querySelector('.features-nav');
    this.navOffsetTop = this.nav.offsetTop;
    this.navHeight = this.nav.offsetHeight;
    const testimonials = <HTMLElement>document.querySelector('#page-helpers');
    this.courseTop = testimonials.offsetTop;
  }

   // tslint:disable-next-line:use-life-cycle-interface
    @HostListener('window:scroll', [])
    onWindowScroll() {
      if (window.pageYOffset > this.navOffsetTop && (window.scrollY + this.navHeight) <= this.courseTop && window.innerWidth > 768) {
         document.body.style.paddingTop = (this.navHeight + 16) + 'px';
         this.fixed = true;
      } else {
         document.body.style.paddingTop = '0';
        this.fixed = false;
      }

      const sec1: HTMLElement = document.querySelector('#section-1');
      const sec2: HTMLElement = document.querySelector('#section-2');
      const sec3: HTMLElement = document.querySelector('#section-3');
      const sec2Top = sec2.offsetTop;
      const sec3Top = sec3.offsetTop;

      // Lavalamp animation
    if ((window.scrollY + this.navHeight + 50) >= sec2Top && (window.scrollY + this.navHeight) < sec3Top) {
      this.removeActiveClass();
      document.querySelector('.section-2-link').classList.add('active');
      this.lavalampBar();
    } else if ((window.scrollY + this.navHeight) >= sec3Top) {
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
    const navs = Array.from(document.querySelectorAll('.features-nav-link'));
    navs.forEach(function (el) {
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
  }

  /* carousel */
  goCourse(id: string) {
    console.log(id);
  }

  ngOnDestroy() {
    // reset padding to 0 if page was left while scrollbar was active
    document.body.style.paddingTop = '0';
  }



}

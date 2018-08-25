import { Component, OnInit } from '@angular/core';
import { BookService } from '../../core/services/book.service';
import { CourseCardComponent } from '../../shared/course-card/course-card.component';


@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {

  courses: any = [];

  constructor(private _books: BookService) { }

   // tslint:disable-next-line:use-life-cycle-interface
   ngOnInit() {
    this.courses.push({
      topic: 'Communication',
      fa: 'fas fa-headset',
      soon: false,
      id: 1,
    });

    this.courses.push({
      topic: 'Strategy',
      fa: 'fab fa-accessible-icon',
      soon: true,
      id: 2,
    });

    this.courses.push({
      topic: 'Teamwork',
      fa: 'fas fa-allergies',
      soon: true,
      id: 3,
    });

    this.courses.push({
      topic: 'Concentration',
      fa: 'fas fa-address-book',
      soon: true,
      id: 4,
    });

  }

  goCourse(id: string) {
    console.log(id);
  }

}

export interface Book {
  author: string;
  title: string;
  ageRestriction: boolean;
}



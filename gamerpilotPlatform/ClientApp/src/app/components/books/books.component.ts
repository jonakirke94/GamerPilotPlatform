import { Component, OnInit } from '@angular/core';
import { BookService } from '../../core/services/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {

  constructor(private _books: BookService) { }

  books: Book[] = [];
  ngOnInit() {
    this._books.getBooks().subscribe( (res) => {
      this.books = <Book[]>res;
      console.log(res);
    });
  }

}

export interface Book {
  author: string;
  title: string;
  ageRestriction: boolean;
}



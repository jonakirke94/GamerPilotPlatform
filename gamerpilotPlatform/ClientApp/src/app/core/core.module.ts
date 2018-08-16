
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StorageService } from './services/storage.service';
import { AuthService } from './services/auth.service';
import { BookService } from './services/book.service';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AuthGuard } from './guards/auth.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
    imports: [
      CommonModule
    ],
    providers: [
      AuthService,
      StorageService,
      AuthGuard,
      BookService,
      {
          provide: HTTP_INTERCEPTORS,
          useClass: AuthInterceptor,
          multi: true
      },
    ],
    declarations: []
  })
  export class CoreModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BooksComponent } from './components/books/books.component';
import { AuthGuard } from './core/guards/auth.guard';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
    { path: '', component: HomeComponent }, // index
    { path: 'home', component: HomeComponent },
/*     { path: 'books', canActivate: [AuthGuard], component: BooksComponent },
 */
    { path: 'books', component: BooksComponent },
    { path: 'fetch-data', component: FetchDataComponent },
/*     { path: '**', redirectTo: 'home' }
 */
  ];

  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule {
  }

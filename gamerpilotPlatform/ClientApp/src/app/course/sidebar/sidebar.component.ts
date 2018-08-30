import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as $ from 'jquery';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  showOutlet = false;

  constructor(private _router: Router) { }

  ngOnInit() {
    // retrieve route and check if the course exists
  }

  toggle(): void {
    $('#sidebar').toggleClass('active');
}
}

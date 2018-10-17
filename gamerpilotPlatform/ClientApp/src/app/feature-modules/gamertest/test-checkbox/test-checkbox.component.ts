import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-test-checkbox',
  templateUrl: './test-checkbox.component.html',
  styleUrls: ['./test-checkbox.component.scss']
})
export class TestCheckboxComponent implements OnInit {
  @Input() value: number;
  @Input() label: string;
  @Output() change = new EventEmitter();
  constructor() { }

  ngOnInit() {
    console.log('value:::', this.value);
  }

  setCheckbox() {
    this.change.emit(this.value);
  }

}

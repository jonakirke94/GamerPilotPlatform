import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlowplayerComponent } from './flowplayer.component';

describe('FlowplayerComponent', () => {
  let component: FlowplayerComponent;
  let fixture: ComponentFixture<FlowplayerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlowplayerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlowplayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

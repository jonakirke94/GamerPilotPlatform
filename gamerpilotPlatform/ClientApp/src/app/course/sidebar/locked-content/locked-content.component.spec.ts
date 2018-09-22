import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LockedContentComponent } from './locked-content.component';

describe('LockedContentComponent', () => {
  let component: LockedContentComponent;
  let fixture: ComponentFixture<LockedContentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LockedContentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LockedContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

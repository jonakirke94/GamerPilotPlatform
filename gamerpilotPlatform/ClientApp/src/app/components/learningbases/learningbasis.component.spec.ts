import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningbasisComponent } from './learningbasis.component';

describe('LearningbasesComponent', () => {
  let component: LearningbasisComponent;
  let fixture: ComponentFixture<LearningbasisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LearningbasisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningbasisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

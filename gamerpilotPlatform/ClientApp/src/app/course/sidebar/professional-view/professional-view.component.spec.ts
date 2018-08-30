import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfessionalViewComponent } from './professional-view.component';

describe('ProfessionalViewComponent', () => {
  let component: ProfessionalViewComponent;
  let fixture: ComponentFixture<ProfessionalViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfessionalViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfessionalViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

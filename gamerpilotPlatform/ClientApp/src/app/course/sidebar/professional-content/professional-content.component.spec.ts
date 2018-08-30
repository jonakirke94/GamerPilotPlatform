import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfessionalContentComponent } from './professional-content.component';

describe('ProfessionalContentComponent', () => {
  let component: ProfessionalContentComponent;
  let fixture: ComponentFixture<ProfessionalContentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfessionalContentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfessionalContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

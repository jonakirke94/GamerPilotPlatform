import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivacyPoliticsComponent } from './privacy-politics.component';

describe('PrivacyPoliticsComponent', () => {
  let component: PrivacyPoliticsComponent;
  let fixture: ComponentFixture<PrivacyPoliticsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrivacyPoliticsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrivacyPoliticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

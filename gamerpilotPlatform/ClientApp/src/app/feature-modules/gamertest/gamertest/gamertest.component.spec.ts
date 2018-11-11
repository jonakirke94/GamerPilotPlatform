import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GamertestComponent } from './gamertest.component';

describe('GamertestComponent', () => {
	let component: GamertestComponent;
	let fixture: ComponentFixture<GamertestComponent>;

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [ GamertestComponent ]
		})
		.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(GamertestComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});

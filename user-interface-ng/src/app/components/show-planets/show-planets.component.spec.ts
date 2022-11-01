import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPlanetsComponent } from './show-planets.component';

describe('ShowPlanetsComponent', () => {
  let component: ShowPlanetsComponent;
  let fixture: ComponentFixture<ShowPlanetsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPlanetsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowPlanetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

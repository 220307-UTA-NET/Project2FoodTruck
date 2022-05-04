import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TruckButtonComponent } from './truck-button.component';

describe('TruckButtonComponent', () => {
  let component: TruckButtonComponent;
  let fixture: ComponentFixture<TruckButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TruckButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TruckButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

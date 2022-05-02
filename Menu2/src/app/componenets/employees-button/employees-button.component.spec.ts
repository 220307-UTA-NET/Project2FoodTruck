import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeesButtonComponent } from './employees-button.component';

describe('EmployeesButtonComponent', () => {
  let component: EmployeesButtonComponent;
  let fixture: ComponentFixture<EmployeesButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeesButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeesButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

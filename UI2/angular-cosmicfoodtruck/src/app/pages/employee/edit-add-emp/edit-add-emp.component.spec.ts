import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAddEmpComponent } from './edit-add-emp.component';

describe('EditAddEmpComponent', () => {
  let component: EditAddEmpComponent;
  let fixture: ComponentFixture<EditAddEmpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAddEmpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAddEmpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

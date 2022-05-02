import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAddTruckComponent } from './edit-add-truck.component';

describe('EditAddTruckComponent', () => {
  let component: EditAddTruckComponent;
  let fixture: ComponentFixture<EditAddTruckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAddTruckComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAddTruckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

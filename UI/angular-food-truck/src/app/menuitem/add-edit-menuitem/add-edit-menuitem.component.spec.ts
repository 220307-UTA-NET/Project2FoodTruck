import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditMenuitemComponent } from './add-edit-menuitem.component';

describe('AddEditMenuitemComponent', () => {
  let component: AddEditMenuitemComponent;
  let fixture: ComponentFixture<AddEditMenuitemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditMenuitemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditMenuitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

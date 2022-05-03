import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOptionsButtonComponent } from './add-options-button.component';

describe('AddOptionsButtonComponent', () => {
  let component: AddOptionsButtonComponent;
  let fixture: ComponentFixture<AddOptionsButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddOptionsButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOptionsButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

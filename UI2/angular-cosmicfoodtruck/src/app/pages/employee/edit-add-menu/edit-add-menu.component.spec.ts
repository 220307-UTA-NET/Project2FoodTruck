import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAddMenuComponent } from './edit-add-menu.component';

describe('EditAddMenuComponent', () => {
  let component: EditAddMenuComponent;
  let fixture: ComponentFixture<EditAddMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAddMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAddMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

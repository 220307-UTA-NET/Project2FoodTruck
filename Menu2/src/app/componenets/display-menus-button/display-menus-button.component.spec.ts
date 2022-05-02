import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayMenusButtonComponent } from './display-menus-button.component';

describe('DisplayMenusButtonComponent', () => {
  let component: DisplayMenusButtonComponent;
  let fixture: ComponentFixture<DisplayMenusButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayMenusButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayMenusButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAboutusComponent } from './show-aboutus.component';

describe('ShowAboutusComponent', () => {
  let component: ShowAboutusComponent;
  let fixture: ComponentFixture<ShowAboutusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowAboutusComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowAboutusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

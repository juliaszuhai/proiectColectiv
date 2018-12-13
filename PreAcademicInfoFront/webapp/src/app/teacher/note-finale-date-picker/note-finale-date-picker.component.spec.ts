import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteFinaleDatePickerComponent } from './note-finale-date-picker.component';

describe('NoteFinaleDatePickerComponent', () => {
  let component: NoteFinaleDatePickerComponent;
  let fixture: ComponentFixture<NoteFinaleDatePickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoteFinaleDatePickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteFinaleDatePickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

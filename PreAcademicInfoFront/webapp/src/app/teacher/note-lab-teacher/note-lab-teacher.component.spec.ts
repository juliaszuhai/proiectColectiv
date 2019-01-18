import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteLabTeacherComponent } from './note-lab-teacher.component';

describe('NoteLabTeacherComponent', () => {
  let component: NoteLabTeacherComponent;
  let fixture: ComponentFixture<NoteLabTeacherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoteLabTeacherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteLabTeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

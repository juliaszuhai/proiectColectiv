import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteLabComponent } from './note-lab.component';

describe('NoteLabComponent', () => {
  let component: NoteLabComponent;
  let fixture: ComponentFixture<NoteLabComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoteLabComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteLabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

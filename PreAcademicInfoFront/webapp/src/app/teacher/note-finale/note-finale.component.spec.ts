import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteFinaleComponent } from './note-finale.component';

describe('NoteFinaleComponent', () => {
  let component: NoteFinaleComponent;
  let fixture: ComponentFixture<NoteFinaleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoteFinaleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteFinaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

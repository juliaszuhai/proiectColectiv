import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteProvizoriiComponent } from './note-provizorii.component';

describe('NoteProvizoriiComponent', () => {
  let component: NoteProvizoriiComponent;
  let fixture: ComponentFixture<NoteProvizoriiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoteProvizoriiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteProvizoriiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

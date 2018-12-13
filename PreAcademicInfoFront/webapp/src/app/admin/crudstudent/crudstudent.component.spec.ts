import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudstudentComponent } from './crudstudent.component';

describe('CrudstudentComponent', () => {
  let component: CrudstudentComponent;
  let fixture: ComponentFixture<CrudstudentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrudstudentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudstudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

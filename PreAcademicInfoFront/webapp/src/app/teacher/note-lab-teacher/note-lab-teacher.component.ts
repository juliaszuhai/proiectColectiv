import { Component, OnInit, Input } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { TeacherService, StudentData } from '../teacher.service';

@Component({
  selector: 'app-note-lab-teacher',
  templateUrl: './note-lab-teacher.component.html',
  styleUrls: ['./note-lab-teacher.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class NoteLabTeacherComponent implements OnInit {

  @Input() materie: string;
  @Input() grupa: string;
  @Input() tipNota: string;

  columnsToDisplay = ['nrMatricol','nume','prezente'];
  grade: string;
  presence: string;
  data: string;
  public students = [];
  expandedElement: StudentData | null;
  nrLabs = [];

  constructor(private teacherService: TeacherService) { }

  ngOnInit() {
    this.teacherService.getStudents(this.materie, this.grupa, this.tipNota)
        .subscribe(data => this.students = data)

    console.log(this.materie);
    console.log(this.grupa);
    console.log(this.tipNota);
  }

  createArray(student: StudentData){
    console.log(student);
    this.nrLabs = Array.from(new Array(student.grades.length + 1),(val,index)=>index+1);
    console.log("here"+ this.nrLabs)
    return this.nrLabs;
  }

  saveGrade(event,elem){
    //save the grade into DB on focusout event
    this.grade=event.target.value;
    console.log(this.grade);
    console.log(this.data);
    //if(this.data != "")
    {
      console.log("len of grades" + elem.grades.len);
      if(elem.grades.length > 0)
      {
        this.teacherService.PostGrade(elem.username, this.grade, this.data,this.materie,this.tipNota,elem.grades[0]["id"]).subscribe(
          data => {
          console.log(data);
        });
      }
      else
      {
        this.teacherService.PostGrade(elem.username, this.grade, this.data,this.materie,this.tipNota,"").subscribe(
          data => {
          console.log(data);
        });
      }

      this.grade = "";
      this.data = "";
    }
  }

  savePresence(event,elem){
    //save presence into DB on focusout event
    this.presence = event.target.value;
    
    console.log(this.presence);
  }


}

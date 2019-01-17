import { Component, OnInit,Input  } from '@angular/core';
import { TeacherService, StudentData } from '../teacher.service';


@Component({
  selector: 'app-note-finale',
  templateUrl: './note-finale.component.html',
  styleUrls: ['./note-finale.component.scss']
})
export class NoteFinaleComponent implements OnInit {

  @Input() materie: string;
  @Input() grupa: string;
  @Input() tipNota: string;

  columnsToDisplay = ['nrMatricol','nume','nota', 'data'];
  grade: string;
  data: string;
  public students = [];

  constructor(private teacherService: TeacherService) { }

  ngOnInit() {
    this.teacherService.getStudents(this.materie, this.grupa, this.tipNota)
        .subscribe(data => this.students = data)

    console.log(this.materie);
    console.log(this.grupa);
    console.log(this.tipNota);
  }

  saveGrade(event,elem){
    //save the grade into DB on focusout event
    this.grade=event.target.value;
    console.log(this.grade);
    if(this.data != "")
    {
      this.teacherService.PostGrade(elem.username, this.grade, this.data,this.materie,this.tipNota).subscribe(
        data => {
        console.log(data);
      });

      this.grade = "";
      this.data = "";
    }
  }

  saveDate(event,elem){
    //save date into DB on focusout event
    this.data = event.target.value;
    console.log(this.grade);
    console.log(this.data);
    console.log(elem.username);
    if(this.grade != "")
    {
      this.teacherService.PostGrade(elem.username, this.grade, this.data,this.materie,this.tipNota).subscribe(
        data => {
        console.log(data);
      });

      this.grade = "";
      this.data = "";
    }
}


}

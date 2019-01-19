import { Component, OnInit,Input  } from '@angular/core';
import { TeacherService, StudentData } from '../teacher.service';
import { ToastrManager } from 'ng6-toastr-notifications';


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
  grade: string = null;
  data: string = null;
  public students = [];

  constructor(private teacherService: TeacherService,public toastr: ToastrManager) { }

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
    console.log(this.data);
    if(this.data !== null)
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

      this.grade = null;
      this.data = null;
    }
    
    else
    {
      this.toastr.warningToastr('Selecteaza data', 'Alert!');
      console.log("baga ba o dataaaaaaaa baaaaa");
    }
  }

  saveDate(event,elem){
    //save date into DB on focusout event
    this.data = event.target.value;
    //console.log(this.grade);
    console.log(this.data);
    //console.log(elem.username);
    if(this.grade !== null )
    {
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
      this.grade = null;
      this.data = null;
    }
}


}

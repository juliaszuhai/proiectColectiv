import { Component, OnInit,Input  } from '@angular/core';
import { TeacherService, StudentData } from '../teacher.service';


const STUDENT_DATA: StudentData[] = [
  {username: "username1", password:"pass1",numarMatricol:"2020",email:"a@ceva.com",nume:"Delibas",prenume:"Stefan", nrTelefon:"00034",CNP:"1934223345",initialaParinte:"V",generatie:"2015",anCurent:"2018"},
  {username: "username2", password:"pass2",numarMatricol:"2039",email:"b@ceva.com",nume:"Szuhai",prenume:"Iulia", nrTelefon:"073534",CNP:"2434254675",initialaParinte:"S",generatie:"2015",anCurent:"2018"}
];

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
  dataSource = STUDENT_DATA;
  nota: string;
  data: string;
  public students = [];

  constructor(private teacherService: TeacherService) { }

  ngOnInit() {
    this.teacherService.getStudents(this.materie, this.grupa, this.tipNota)
        .subscribe(data => this.students = data)

    this.nota = "";
    this.data = "";
    console.log(this.materie);
    console.log(this.grupa);
    console.log(this.tipNota);
  }

  saveGrade(event,elem){
    //save the grade into DB on focusout event
    this.nota=event.target.value;

    if(this.data != "")
    {
      this.teacherService.PutGrade(elem.username, this.nota, this.data,this.materie,this.tipNota);
      this.nota = "";
      this.data = "";
    }
  }

  saveDate(event,elem){
    //save date into DB on focusout event
    this.data = event.target.value;
    console.log(this.data);
    console.log(elem.username);
    if(this.nota != "")
    {
      //this.teacherService.PutGrade(elem.username, this.nota, this.data,this.materie,this.tipNota);
      this.nota = "";
      this.data = "";
    }
  }

}

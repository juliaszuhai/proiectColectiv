import { Component, OnInit } from '@angular/core';
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

  columnsToDisplay = ['nrMatricol','nume','nota', 'data'];
  dataSource = STUDENT_DATA;
  nota: string;
  data: string;
  public students = [];

  constructor(private teacherService: TeacherService) { }

  ngOnInit() {
    this.teacherService.getStudents()
        .subscribe(data => this.students = data)
  }

  saveGrade(event){
    //save the grade into DB on focusout event
    this.nota=event.target.value;
    console.log(this.nota);
  }

  saveDate(event){
    //save date into DB on focusout event
    this.data = event.target.value;
    console.log(this.data);
  }

}

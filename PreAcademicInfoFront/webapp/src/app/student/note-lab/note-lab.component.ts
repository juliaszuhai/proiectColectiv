import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {GradeData, StudentService} from "../student.service";

@Component({
  selector: 'app-note-lab',
  templateUrl: './note-lab.component.html',
  styleUrls: ['./note-lab.component.scss']
})
export class NoteLabComponent implements OnInit {
  seven:boolean=true;
  grades:GradeData[];
  materii;

  constructor(private studentService:StudentService, private router: Router ) { }

  ngOnInit() {
    var username=localStorage.getItem("username");
    this.studentService.getEnrolledDisciplines(username).subscribe(
      data =>
        this.materii = data
    )

  }

  onChangeMaterie(e) {
    var materieSelectata=e.value;
    console.log(materieSelectata);
    var username=localStorage.getItem("username");
    this.studentService.getLabGrades(username).subscribe(
      data =>
        this.grades = data

    );
    if( this.grades.length>7)
    {
      this.seven=true;
    }
    else
    {
      this.seven=false;
    }
  }
}

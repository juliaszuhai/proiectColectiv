import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {GradeData, LabGrade, StudentService} from "../student.service";

@Component({
  selector: 'app-note-lab',
  templateUrl: './note-lab.component.html',
  styleUrls: ['./note-lab.component.scss']
})

export class NoteLabComponent implements OnInit {


  constructor(private studentService:StudentService, private router: Router ) { }

  seven:number=0;
  materii=[];
  displayedColumns=['value', 'data'];
  noteleInitiale:LabGrade[];
  notele:LabGrade[];


  ngOnInit() {
    var username=localStorage.getItem("username");
    this.studentService.getEnrolledDisciplines(username).subscribe(
      data =>
      {

          for (var _i = 0; _i < data.length; _i++) {
            //console.log(data[_i]);
            this.materii.push({value: _i.toString(), viewValue: data[_i]});
          }

      }
    );
    this.notele = [];
    this.noteleInitiale=[];
  }

  onChangeMaterie(e) {
    var materieSelectata=this.materii[e.value].viewValue;
    var username=localStorage.getItem("username");
    this.studentService.getLabGrades(username, materieSelectata).subscribe(
      data =>
      {this.seven=1;
        for (var _i = 0; _i < data.length; _i++)
        {
          this.noteleInitiale.push({id: data[_i]["id"], data: data[_i]["data"], value: data[_i]["value"]});
        }
        this.notele=this.noteleInitiale;
        this.noteleInitiale=[];
        console.log(this.notele);
        });
  }
}

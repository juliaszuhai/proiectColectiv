import { Component, OnInit } from '@angular/core';
import {User, AdminService,Student } from '../admin.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.scss']
})
export class StudentsListComponent implements OnInit {

  constructor(private adminService:AdminService, private http: HttpClient) { }

  columnsToDisplay=['Numar matricol', 'Nume', 'Prenume', 'Email', 'Telefon', 'DeleteButton', 'UpdateButton']
  public studentsList = []
  ani = [
    {value: '1', viewValue: 'Anul 1'},
    {value: '2', viewValue: 'Anul 2'},
    {value: '3', viewValue: 'Anul 3'},
  ];

  ngOnInit() {
    this.adminService.getStudents()
        .subscribe(data =>{
          this.studentsList = data;
        })
        console.log(this.studentsList)
  }

  onChangeAn(event:any) {
    //console.log(event.value);
    let an=event.value;
    this.adminService.getStudentsByYear(an)
    .subscribe(data =>{
      this.studentsList = data;
    })
    console.log(this.studentsList)
    //console.log(this.dataSource);

  }

  deleteStudent (username: string){
    console.log(username);
    this.adminService.deleteStudent(username)
    .subscribe(
      data => {
          console.log("Deleted!");
          this.ngOnInit();
      },
      err => {
        console.log(err);
      }
    );
  }



  updateStudent (student: Student){
    console.log("student details component")
    console.log(student)
    this.adminService.updateStudent(student)
    .subscribe(
      data => {
          console.log("Updated!");
      },
      err => {
        console.log(err);
      }
    );
  }

}

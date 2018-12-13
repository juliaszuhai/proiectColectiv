import { Component, OnInit } from '@angular/core';
import {User, AdminService } from '../admin.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.scss']
})
export class StudentsListComponent implements OnInit {

  constructor(private adminService:AdminService, private http: HttpClient) { }

  columnsToDisplay=['Numar matricol', 'Nume', 'Prenume', 'Email', 'Telefon', 'DeleteButton']
  public studentsList = []
  ngOnInit() {
    this.adminService.getStudents()
        .subscribe(data =>{
          this.studentsList = data;
          console.log(data)
        })
        console.log(this.studentsList)
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

}

import { Component, OnInit } from '@angular/core';
import {User,Teacher, AdminService} from "../admin.service"

@Component({
  selector: 'app-teachers-list',
  templateUrl: './teachers-list.component.html',
  styleUrls: ['./teachers-list.component.scss']
})

export class TeachersListComponent implements OnInit {

  constructor(private adminService:AdminService) { }

  columnsToDisplay=['Nume', 'Prenume', 'Email', 'Telefon', 'Discipline', 'DeleteButton'];

  public teachersList = []

  ngOnInit() {
    this.adminService.getTeachers()
        .subscribe(data =>{
          this.teachersList = data;
          console.log(data)
        })
        console.log(this.teachersList)
  }

  deleteTeacher (username: string){
    console.log(username);
    this.adminService.deleteTeacher(username)
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

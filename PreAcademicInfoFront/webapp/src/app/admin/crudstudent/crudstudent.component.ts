import {Component} from '@angular/core';

import { MatRadioChange } from '@angular/material/radio';
import {AdminService, User} from '../admin.service';

/** @title Form field with label */
@Component({
  selector: 'app-crudstudent',
  templateUrl: './crudstudent.component.html',
  styleUrls: ['./crudstudent.component.scss']
})

export class CrudstudentComponent {
  user: User;
  isStudent: boolean;

  selected: string;
  filter: any;

  usertypes = ['Student', 'Teacher', 'Admin'];

  ngOnInit() {
    this.isStudent = true;
  }

  radioChange(event: MatRadioChange) {
    if(event.value == 'Student')
    {
      this.isStudent = true;
    }
    else
    {
      this.isStudent = false;
    }
  }

  submitForm(){
    console.log(this.user);
    this.adminService.addUser(this.user)
    .subscribe(
      data => {
          console.log("Added!");
      },
      err => {
        console.log(err);
      }
    );
  }

  constructor(private adminService: AdminService) {
    this.user = {
      username : '',
      nume : '',
      prenume: '',
      type: '',
      cnp:'',
      numarMatricol:'',
      telefon:'',
      email:'',
      initiale:'',
      adresa:''
    }



  }
}

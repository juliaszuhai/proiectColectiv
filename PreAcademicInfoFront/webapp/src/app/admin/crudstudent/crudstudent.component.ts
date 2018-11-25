import {Component} from '@angular/core';
import { User } from '../admin-service.service.spec';
import { MatRadioChange } from '@angular/material/radio';
import { AdminService } from '../admin.service';

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
    this.user.type = event.value;
    console.log(this.user.nume);
  }

  submitForm(){
    this.adminService.addUser(this.user)
    .subscribe(
      data => {
        
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
      nrMatricol:'',
      telefon:'',
      email:'',
      initiale:'',
      adresa:''
    }

    
    
  }
}
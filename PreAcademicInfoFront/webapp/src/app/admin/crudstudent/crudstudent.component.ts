import {Component} from '@angular/core';
import { User } from '../admin-service.service.spec';

/** @title Form field with label */
@Component({
  selector: 'app-crudstudent',
  templateUrl: './crudstudent.component.html',
  styleUrls: ['./crudstudent.component.scss']
})

export class CrudstudentComponent {

  user: User;


  constructor() {
    this.user = {
      username : '',
      nume : '',
      prenume: '',
      type: '',
      cnp:''
    }
    
  }
}
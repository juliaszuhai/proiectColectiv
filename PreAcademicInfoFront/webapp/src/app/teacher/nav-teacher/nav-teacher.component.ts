import { Component, OnInit } from '@angular/core';
import {AuthenticationServiceService, NewPassData} from "../../signin/authentication-service.service";
import { TeacherService } from '../teacher.service';
import {Router} from "@angular/router";
@Component({
  selector: 'app-nav-teacher',
  templateUrl: './nav-teacher.component.html',
  styleUrls: ['./nav-teacher.component.scss']
})
export class NavTeacherComponent implements OnInit {

  newPassData: NewPassData;
  checkedChangePassword = false;
  error = false;
  errorMessage = ''
  constructor(private authService: AuthenticationServiceService, private teacherService: TeacherService,
              private router: Router) {
                this.newPassData = {
                  username: '',
                  old_password: '',
                  new_password: '',
                  confirm_new_password: ''
                };
               }

  ngOnInit() {
  }

  displayError(){
    return this.error;
  }

  getMessage(){
    return this.errorMessage;
  }

  changePassword(){
    this.teacherService.changePassword(this.newPassData.old_password,
      this.newPassData.new_password, this.newPassData.confirm_new_password )
    .subscribe(
      data => {
        console.log(data);
        this.error = true;
        this.errorMessage = "Successfully updated password"
      },
      err => {
        this.error = true;
        this.errorMessage = "Old password is incorrect or new passwords do not match";
      }
    );
  }

}

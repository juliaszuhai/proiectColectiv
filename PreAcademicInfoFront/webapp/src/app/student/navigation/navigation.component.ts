import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {AuthenticationServiceService, NewPassData} from "../../signin/authentication-service.service";
import {StudentService} from "../student.service"
@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
  providers: [AuthenticationServiceService]
})
export class NavigationComponent implements OnInit {

  newPassData: NewPassData;
  error = false;
  errorMessage = ''
  constructor(private authService: AuthenticationServiceService, private studentService: StudentService,
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
    this.studentService.changePassword(this.newPassData.old_password,
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


  getFirstName() {
    return localStorage['firstName'];
  }

  public hasPermission(perm) {
    return this.authService.userHasPermission(perm);
  }

}

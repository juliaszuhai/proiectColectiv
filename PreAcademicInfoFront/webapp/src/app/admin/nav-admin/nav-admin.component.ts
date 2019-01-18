import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { AuthenticationServiceService, NewPassData } from 'src/app/signin/authentication-service.service';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-navigation-admin',
  templateUrl: './nav-admin.component.html',
  styleUrls: ['./nav-admin.component.scss'],
  providers: [AuthenticationServiceService]
})
export class NavAdminComponent implements OnInit {

  checkedChangePassword = false;
  error = false;
  errorMessage = '';
  newPassData: NewPassData;

  constructor(private authService: AuthenticationServiceService,private adminService:AdminService,
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
    this.adminService.changePassword(this.newPassData.old_password,
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


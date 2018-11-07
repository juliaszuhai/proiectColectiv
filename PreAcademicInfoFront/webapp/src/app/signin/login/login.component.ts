import { Component, OnInit } from '@angular/core';
import { UserLoginData, AuthenticationServiceService } from '../authentication-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  userLoginData: UserLoginData;
  error: boolean;
  errorMessage: string;

  constructor(private authenticationService: AuthenticationServiceService, private router: Router) { 
    this.userLoginData = {
      username: '',
      password: '',
    };
    this.error = false;
    this.errorMessage = '';
  }

  displayError(){
    return this.error;
  }

  getMessage(){
    return this.errorMessage;
  }

  validatePassword(){

  }

  submitForm(){
    this.authenticationService.loginUser(this.userLoginData.username,this.userLoginData.password)
    .subscribe(
      data => {
        this.error = false;
        this.router.navigate([`/home`]);
      },
      err => {
        this.error = true;
        this.errorMessage = "Invalide username or password";
      }
    );
  }

  ngOnInit() {
  }

}

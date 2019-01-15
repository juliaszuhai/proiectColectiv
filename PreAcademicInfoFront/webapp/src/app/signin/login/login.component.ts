import { Component, OnInit } from '@angular/core';
import { UserLoginData, AuthenticationServiceService } from '../authentication-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [AuthenticationServiceService]
})
export class LoginComponent implements OnInit {

  userLoginData: UserLoginData;
  error: boolean;
  clickedLogin:boolean;
  errorMessage: string;

  constructor(private authenticationService: AuthenticationServiceService, private router: Router) {
    this.userLoginData = {
      username: '',
      password: '',
    };
    this.error = false;
    this.errorMessage = '';
    this.clickedLogin=false;
  }

  displayError(){
    return this.error;
  }

  getMessage(){
    return this.errorMessage;
  }

  validatePassword(){

  }

  clickedButton(){
    return this.clickedLogin;
  }

  submitForm(){
    this.clickedLogin=true;
    this.authenticationService.loginUser(this.userLoginData.username,this.userLoginData.password)
    .subscribe(
      data => {
        console.log(data);
        this.error = false;
        if(localStorage.getItem("type") == "1")
        {
            this.router.navigate(['../home']);
        }
        if(localStorage.getItem("type") == "0")
        {
            this.router.navigate(['../teacher']);
        }
        if(localStorage.getItem("type") == "2")
        {
            this.router.navigate(['../crud']);
        }
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

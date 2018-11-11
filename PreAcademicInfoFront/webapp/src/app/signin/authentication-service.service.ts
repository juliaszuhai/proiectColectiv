import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import {tap} from 'rxjs/operators';
import {JwtHelperService} from '@auth0/angular-jwt';

export interface UserLoginData {
  username: string;
  password: string;
}
@Injectable()
export class AuthenticationServiceService {

  baseURL = 'http://localhost:8080';
  isLoggedIn=false;

  constructor(private http: HttpClient,
              private router: Router) {
  }

  public isLogged()
  {
    return this.isLoggedIn;
  }

  loginUser(username: string, password: string){
    let body = new URLSearchParams();
    body.set('username', username);
    body.set('password', password);
    console.log(username, password);

    return this.http.post<UserLoginData>(this.baseURL,
      body.toString(),
      {
      headers: new HttpHeaders(
        {'Content-Type' : 'application/json'}
      )
    }).pipe(
      tap(res => this.setSession(res))
    );
  }

  private setSession(res){

    this.isLoggedIn=true;

  }

}

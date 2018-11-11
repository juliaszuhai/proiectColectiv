import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import {tap} from 'rxjs/operators';

export interface UserLoginData {
  username: string;
  password: string;
}
@Injectable()
export class AuthenticationServiceService {

  baseURL = 'http://localhost:53087/api/Login';
  isLoggedIn=false;


  constructor(private http: HttpClient,
              private router: Router) {
  }

  public isLogged()
  {
    return this.isLoggedIn;
  }

  loginUser(username: string, password: string){
    let body = JSON.stringify({username,password});
    console.log(username, password);

    return this.http.post<UserLoginData>(this.baseURL,
      body,

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

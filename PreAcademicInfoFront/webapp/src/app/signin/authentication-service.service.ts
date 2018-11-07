import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import {tap} from 'rxjs/operators';

export interface UserLoginData {
  username: string;
  password: string;
}


@Injectable({
  providedIn: 'root'
})
export class AuthenticationServiceService {

  baseURL = 'http://localhost:8080';

  constructor(private http: HttpClient,
              private router: Router) {
  }

  public getToken(): string {
    return localStorage.getItem('token');
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
    // to be implemented
  }

}

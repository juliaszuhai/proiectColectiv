import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from './admin-service.service.spec';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  
  baseURL = 'http://localhost:53087/api/';

  constructor(private http: HttpClient,
    private router: Router) { }

    addUser( user:User)
      {
        if(user.type == "Student")
        {
          let bodyStudent = JSON.stringify(
            {
              nume: user.nume,
              prenume: user.prenume,
              email: user.email,
              cnp: user.cnp,
              numarMatricol: user.nrMatricol,
              username: user.username,
              numartelefon: user.telefon,
              InitialaParinte: user.initiale,
              
            });
          console.log(bodyStudent);
      
          return this.http.post<User>(this.baseURL+user.type+"s",
            bodyStudent,
            {
            headers: new HttpHeaders(
              {'Content-Type' : 'application/json'}
            )
          });
        }
        else
        {
          let body = JSON.stringify(
            {
              nume: user.nume,
              prenume: user.prenume,
              email: user.email,
              username: user.username,
              numartelefon: user.telefon              
            });
          console.log(body);
      
          return this.http.post<User>(this.baseURL+user.type+"s",
            body,
            {
            headers: new HttpHeaders(
              {'Content-Type' : 'application/json'}
            )
          });
        }
    }
}

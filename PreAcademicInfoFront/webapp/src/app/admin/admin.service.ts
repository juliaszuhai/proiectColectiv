import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

export interface User{
  username: string;
  nume: string;
  prenume: string;
  type: string;
  cnp: string;
  telefon: string;
  email: string;
  initiale: string;
  numarMatricol: string;
  adresa: string;
}
export interface Teacher{
  username: string;
  nume: string;
  prenume: string;
  type: string;
  telefon: string;
  email: string;
  dicipline: string[]
}
@Injectable()
export class AdminService {


  baseURL = 'http://localhost:6603/api/';
  baseURLTeachers='http://localhost:6603/api/Teachers';
  baseUrlStudents='http://localhost:6603/api/Students';

  constructor(private http: HttpClient,
    private router: Router) { }

    getTeachers(): Observable<Teacher[]>{
       return this.http.get<Teacher[]>(this.baseURLTeachers); 
      }

    getStudents(): Observable<User[]>{ return this.http.get<User[]>(this.baseUrlStudents); }

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
              nrMatricol: user.numarMatricol,
              username: user.username,
              telefon: user.telefon,
              initiale: user.initiale,

            });
          console.log(bodyStudent);

          return this.http.post<User>(this.baseURL+"Students",
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

    deleteStudent( username: string)
      {

          return this.http.delete(this.baseURL+"Students/" + username )
            {
            headers: new HttpHeaders(
              {'Content-Type' : 'application/json'}
            )
          };
        }

        deleteTeacher( username: string)
      {

          return this.http.delete(this.baseURL+"Teachers/" + username )
            {
            headers: new HttpHeaders(
              {'Content-Type' : 'application/json'}
            )
          };
        }
}

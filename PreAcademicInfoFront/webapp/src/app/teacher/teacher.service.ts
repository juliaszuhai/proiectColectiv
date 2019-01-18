import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {tap} from "rxjs/operators";
import { Observable } from 'rxjs';
import { NewPassData } from '../signin/authentication-service.service';

export interface StudentData {
  username: string;
  password: string;
  numarMatricol: string;
  email : string;
  nume: string;
  prenume: string;
  nrTelefon: string;
  CNP: string;
  initialaParinte: string;
  generatie: string;
  anCurent: string;
}

@Injectable()
export class TeacherService {

  baseURL = 'https://localhost:44354/api/Students';
  changePassURL = 'https://localhost:44354/api/ChangePass';
  constructor(private http: HttpClient,
              private router: Router)
  { }

  changePassword(oldPassword: string, newPassword: string, confirmNewPassword: string){
    let username = localStorage['username']
    let body = JSON.stringify({username,oldPassword,newPassword,confirmNewPassword});
    console.log(localStorage['username']);
    return this.http.put<NewPassData>(this.changePassURL,
      body,
      {
      headers: new HttpHeaders(
        {'Content-Type' : 'application/json'}
      )
    })
  }

  getStudents(materie:string, grupa: string, tipNota:string): Observable<StudentData[]>{
      return this.http.get<StudentData[]>(this.baseURL);
  }


}
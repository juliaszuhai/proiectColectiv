import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {tap} from "rxjs/operators";
import {UserLoginData} from "./signin/authentication-service.service";


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

export interface GradeData {
  an:string;
  semestru:string;
  numeMaterie:string;
  nrCredite:string;
  dataPromovarii:string;
  codMaterie:string;
  nota:string;
  descriere:string;
}
@Injectable()
export class StudentService {

  baseURL = 'http://localhost:53087/api/Students';

  constructor(private http: HttpClient,
              private router: Router)
  { }

  getStudent(username:string){
    let body = JSON.stringify({username});
    console.log(username);

    return this.http.post<StudentData>(this.baseURL,
      body,
      {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )
      }).pipe(
      tap(res => this.setStudent(res))
    );
  }

  getFinalGradesForStudent(username:string){
    let body = JSON.stringify({username});
    console.log(username);

    return this.http.post<GradeData>(this.baseURL,
      body,
      {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )
      }).pipe(
      tap(res => this.setStudent(res))
    );
  }

  private setStudent(res: any) {

  }
}

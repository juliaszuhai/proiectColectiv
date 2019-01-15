import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {tap} from "rxjs/operators";
import { Observable } from 'rxjs';


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

export interface StudentGrade{
  username:string;
  grade:string;
  data:string;
  materie:string;
  tipNota:string;
}

@Injectable()
export class TeacherService {

  baseURL = 'http://localhost:53087/api/Students';
  gradesURL = 'http://localhost:53087/api/Grades';

  constructor(private http: HttpClient,
              private router: Router)
  { }

  getStudents(materie:string, grupa: string, tipNota:string): Observable<StudentData[]>{
      return this.http.get<StudentData[]>(this.baseURL+ "/" + materie + "/"+ grupa + "/" + tipNota);
  }

  PutGrade(username:string, nota:string, data: string,materie:string,tipNota:string)
  {
    let body = JSON.stringify({username,nota,data,materie,tipNota});
    console.log("i got hereeeeeee");
    return this.http.post(this.gradesURL,
            body,
            {
            headers: new HttpHeaders(
              {'Content-Type' : 'application/json'}
            )
          });
  }
}
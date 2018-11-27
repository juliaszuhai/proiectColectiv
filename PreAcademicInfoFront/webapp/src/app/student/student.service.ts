import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {tap} from "rxjs/operators";


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

export interface DisciplineData{
  An:string;
  semestru:string;
  nume:string;
  obligatoriu:boolean;
  optional:boolean;
  facultativ:boolean;
  codMaterie:string;
  nrCredite:string;
  locuriDisponibile:number;
  locuriOcupate:number;
}

export interface SpecializareData{
  facultatea:string,
  nume:string,
  semestre:string,
  discipline: DisciplineData[]

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

  getContracteStudii() {
    let username = localStorage.getItem('username');
    let params = new HttpParams();
    params.append("username",username);
    console.log(username);

    return this.http.get<SpecializareData>(this.baseURL,{params: params});
  }
}

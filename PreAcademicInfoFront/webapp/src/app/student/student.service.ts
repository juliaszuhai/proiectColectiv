import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {tap} from "rxjs/operators";
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
  note:GradeToDiscipline[];
}
export interface GradeToDiscipline{
  discipline:string;
  grades:GradeData[];
}

export interface GradeData {
  numeMaterie:string;
  an:string;
  semestru:string;
  nrCredite:string;
  dataPromovarii:string;
  codMaterie:string;
  nota:string;
  specializare:string;
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
export interface Departament{
  name:string;
  faculty:string;
}

export interface SpecializareData{
  nume:string;
  departament:Departament;
  specializareType:string;
  limba:string;
  numarSemestre:string;
  taxaPerCredit:string;
  cuFrecventa:string;
  discipline:DisciplineData[];
}
@Injectable()
export class StudentService {

  baseURL = 'https://localhost:44354/api/Students';
  gradesURL = 'https://localhost:44354/api/Grades';
  changePassURL = 'https://localhost:44354/api/ChangePass'
  baseURLDisciplines='https://localhost:44354/api/Discipline';
  baseURLSpecializari='https://localhost:44354/api/Specializari';

  constructor(private http: HttpClient,
              private router: Router)
  { }

  getStudent(username:string){
    return this.http.get(this.baseURL+"/"+username,
      {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )
      });
  }

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

  getGrades(username:string)
  {
    return this.http.get(this.gradesURL+"/"+username,
    {
      headers: new HttpHeaders(
        {'Content-Type' : 'application/json'}
      )
    });
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

  getSpecializari() {
    return this.http.get<SpecializareData[]>(this.baseURLSpecializari,
      {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )});
  }
}

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
  note:GradeToDiscipline[];
}
export interface GradeToDiscipline{
  discipline:string;
  grades:GradeData[];
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

  baseURL = 'http://localhost:53087/api/Students';
  baseURLDisciplines='http://localhost:53087/api/Discipline';
  baseURLSpecializari='http://localhost:53087/api/Specializari';

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

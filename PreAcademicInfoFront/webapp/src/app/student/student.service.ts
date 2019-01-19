import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {tap} from "rxjs/operators";
import { NewPassData } from '../signin/authentication-service.service';
import { Observable } from 'rxjs';


export interface StudentData {
  username: string;
  password: string;
  numarMatricol: string;
  email: string;
  nume: string;
  prenume: string;
  nrTelefon: string;
  CNP: string;
  initialaParinte: string;
  generatie: string;
  anCurent: string;
  note: GradeToDiscipline[];
}
export interface GradeToDiscipline {
  discipline: string;
  grades: GradeData[];
}

export interface GradeData {
  numeMaterie: string;
  an: string;
  semestru: string;
  nrCredite: string;
  dataPromovarii: string;
  codMaterie: string;
  notaExamen: string;
  notaFinala: string;
  specializare: string;
}

export interface DisciplineData{
  An:string;
  semestru:string;
  nume:string;
  type:string;
  codMaterie:string;
  nrCredite:string;
  locuriDisponibile:number;
  locuriOcupate:number;
}
export interface Departament {
  name: string;
  faculty: string;
}

export interface SpecializareData {
  nume: string;
  departament: Departament;
  specializareType: string;
  limba: string;
  numarSemestre: string;
  taxaPerCredit: string;
  cuFrecventa: string;
  discipline: DisciplineData[];
}
export interface LabGrade {
  id: string;
  value: string;
  data: string;
}

export interface TeacherData{
  Nume:string;
  Prenume: string;
  Email:string;
  PictureURL:string;
  Website:string;
}

@Injectable()
export class StudentService {

  baseURL = 'https://localhost:44354/api/Students';
  gradesURL = 'https://localhost:44354/api/Grades';

  changePassURL = 'https://localhost:44354/api/ChangePass'
  baseURLDisciplines='https://localhost:44354/api/Discipline';
  baseURLSpecializari='https://localhost:44354/api/Specializari';
  teacherURL='https://localhost:44354/api/Teachers';
  

  constructor(private http: HttpClient,
    private router: Router) { }

  getStudent(username: string) {
    return this.http.get(this.baseURL + "/" + username,
      {
        headers: new HttpHeaders(
          { 'Content-Type': 'application/json' }
        )
      });
  }

  getGrades(username: string) {
    return this.http.get(this.gradesURL + "/" + username,
      {
        headers: new HttpHeaders(
          { 'Content-Type': 'application/json' }
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

  private setStudent(res: any) {

  }

  getContracteStudii() {
    let username = localStorage.getItem('username');
    let params = new HttpParams();
    params.append("username", username);
    console.log(username);

    return this.http.get<SpecializareData>(this.baseURL, { params: params });
  }

  getSpecializari(username:string) {
    return this.http.get<string[]>(this.baseURL+"/specializari/"+username,
      {
        headers: new HttpHeaders(
          { 'Content-Type': 'application/json' }
        )
      });
  }

  getTeachersDetails() {
    return this.http.get<TeacherData[]>(
      this.teacherURL+"/showcase/",
      {
        headers: new HttpHeaders(
          { 'Content-Type': 'application/json' }
        )
      });
  }

  getLabGrades(username: string, materieSelectata: string) {
    return this.http.get<LabGrade[]>(this.baseURL + "/noteLab/" + username + "/" + materieSelectata,
      {
        headers: new HttpHeaders(
          { 'Content-Type': 'application/json' }
        )
      });
  }

  getEnrolledDisciplines(username: string) {
    return this.http.get<string[]>(this.baseURLDisciplines + '/materii/student/' + username,
      {
        headers: new HttpHeaders(
          { 'Content-Type': 'application/json' }
        )
      });

  }

  getAvailableDisciplines(selectedSpecializare:string,selectedAn:string,selectedStemestru:string) {
    return this.http.get<DisciplineData[]>(this.baseURLDisciplines+"/listDisciplines/"+selectedSpecializare+"/"+selectedAn+"/"+selectedStemestru,
      {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )
      }
    );
  }

  saveContract(materiiSelectate: DisciplineData[]) {
    console.log(materiiSelectate);
    var lista=[];
    for(var i=0;i<materiiSelectate.length;i++)
    {
      lista.push({"codMaterie":materiiSelectate[i].codMaterie});
    }
    var username=localStorage.getItem("username");
    let body=JSON.stringify({lista,username});
    return this.http.post(this.baseURL,body,{
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    })
  }

  getMaterii(
    teacher:string
  ) :Observable<string[]> {
    return this.http.get<string[]>(
      this.baseURLDisciplines + "/toatematerile/"+localStorage['username']
    );
  }
  
}

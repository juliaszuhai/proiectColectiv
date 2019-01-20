import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {tap} from "rxjs/operators";
import { Observable } from 'rxjs';
import { NewPassData } from '../signin/authentication-service.service';

export interface StudentData {
  username: string;
  numarMatricol: string;
  nume: string;
  prenume: string;
  prezenteLab: string;
  prezenteSeminar: string;
  grades: GradesData[];
}
export interface GradesData {
  id: string;
  value: string;
  data: string;
}

export interface StudentGrade {
  username: string;
  grade: string;
  data: string;
  materie: string;
  tipNota: string;
}

export interface Percentage{
  materie:string;
  procentajExamen:string;
  procentajPartial:string;
  procentajSeminar:string;
  procentajBonus:string;
  procentajLabOuter:string;
  procentajeLab:string[];
}
@Injectable()
export class TeacherService {
  baseURL = "https://localhost:44354/api/Students";
  gradesURL = "https://localhost:44354/api/Grades";
  disciplineURL = "https://localhost:44354/api/Discipline";
  groupURL = "https://localhost:44354/api/Groups";

  constructor(private http: HttpClient, private router: Router) {}

  getMaterii(
    teacher:string
  ) :Observable<string[]> {
    return this.http.get<string[]>(
      this.disciplineURL + "/" + "materii/teacher/" + teacher 
    );
  }

  getGrupe(
    teacher:string
  ) :Observable<string[]> {
    return this.http.get<string[]>(
      this.groupURL + "/" + teacher 
    );
  }
  changePassURL = 'https://localhost:44354/api/ChangePass';

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

  getStudents(
    materie: string,
    grupa: string,
    tipNota: string
  ): Observable<StudentData[]> {
    return this.http.get<StudentData[]>(
      this.baseURL + "/" + materie + "/" + grupa + "/" + tipNota
    );
  }


  PostProcentaje(
  materie:string,
  examenP:number,
  partialP:number,
  seminarP:number,
  bonusP:number,
  laboratorP:number,
  labs:number[]
  ) {
  let examen:string,partial:string, seminar:string, bonus:string, laboratorS:string;
  if(examenP == 0) {examen = ""; }
  else{examen = examenP.toString();}
  if(laboratorP == 0) {laboratorS = ""; }
  else{laboratorS = laboratorP.toString();}
  if(partialP == 0) { partial = ""; }
  else{partial = partialP.toString();}
  if(seminarP == 0) { seminar = ""; }
  else{seminar = seminarP.toString();}
  if(bonusP == 0) { bonus = ""; }
  else{bonus = bonusP.toString();}

  let list = [];
  list.push(laboratorS);
  let laborator = {"Inner":labs,"Outer":list}
  let body = JSON.stringify({ materie, examen, partial, seminar, bonus, laborator });
   return this.http.post<Percentage>(this.gradesURL+"/percentage", body, {
     headers: new HttpHeaders({ "Content-Type": "application/json" })
   });
  }

  ComputeNotaFinala(materie:string)
  {
    return this.http.post<Percentage>(this.gradesURL+"/ComputeFinalGrade/"+materie, {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    });
  }
  PostGrade(
    username: string,
    grade: string,
    data: string,
    materie: string,
    tipNota: string,
    idNota: string
  ) {
    console.log("we got right before the call");
    let body = JSON.stringify({ username, grade, data, materie, tipNota, idNota });
    console.log(body);
    return this.http.post<StudentGrade>(this.gradesURL, body, {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    });
  }

  PostPrezenta (
    materie: string,
    usernameStudent: string,
    noAttendance: string)
    {

      console.log(materie + " " + usernameStudent + " " + noAttendance);
      return this.http.post(
        this.disciplineURL + "/prezenteLab/" + materie + "/" + usernameStudent + "/" + noAttendance , 
        {
          headers: new HttpHeaders({ "Content-Type": "application/json" })
        });

    }
  }

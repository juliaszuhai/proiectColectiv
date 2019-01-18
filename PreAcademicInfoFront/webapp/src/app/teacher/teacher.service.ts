import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { tap } from "rxjs/operators";
import { Observable } from "rxjs";

export interface StudentData {
  username: string;
  numarMatricol: string;
  nume: string;
  prenume: string;
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
export interface Materie{
  numeMaterie:string
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


  getStudents(
    materie: string,
    grupa: string,
    tipNota: string
  ): Observable<StudentData[]> {
    return this.http.get<StudentData[]>(
      this.baseURL + "/" + materie + "/" + grupa + "/" + tipNota
    );
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
}

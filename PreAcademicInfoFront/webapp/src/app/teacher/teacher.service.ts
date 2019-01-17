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

@Injectable()
export class TeacherService {
  baseURL = "https://localhost:44354/api/Students";
  gradesURL = "https://localhost:44354/api/Grades";

  constructor(private http: HttpClient, private router: Router) {}

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
    tipNota: string
  ) {
    let body = JSON.stringify({ username, grade, data, materie, tipNota });
    console.log(body);
    return this.http.post<StudentGrade>(this.gradesURL, body, {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    });
  }
}

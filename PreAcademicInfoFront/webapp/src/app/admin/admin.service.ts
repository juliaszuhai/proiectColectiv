import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

export interface User{
  username: string;
  nume: string;
  prenume: string;
  type: string;
  cnp: string;
  telefon: string;
  email: string;
  initiale: string;
  numarMatricol: string;
  adresa: string;
}

export interface Student{
  username: string;
  nume: string;
  prenume: string;
  type: string;
  cnp: string;
  numarTelefon: string;
  email: string;
  initialaParinte: string;
  numarMatricol: string;
  adresa: string;
  salt: string;
  password:string;
  generatie: string;
  an:string;

}
export interface Teacher{
  username: string;
  nume: string;
  prenume: string;
  numarTelefon: string;
  email: string;
  type: string;
  salt: string;
  password:string;
  disciplinesHolded: string[]
}
export interface Mail{
  titlu: string;
  mesaj: string;
  departament: string;
  an:string;
  grupa:string;
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
export class AdminService {
  


  baseURL = 'https://localhost:44354/api/';
  baseURLTeachers='https://localhost:44354/api/Teachers';
  baseUrlStudents='https://localhost:44354/api/Students';

  constructor(private http: HttpClient,
    private router: Router) { }

    getTeachers(): Observable<Teacher[]>{
       return this.http.get<Teacher[]>(this.baseURLTeachers); 
      }

    getStudents(): Observable<Student[]>{ return this.http.get<Student[]>(this.baseUrlStudents); }

    getStudentsByYear(an:string): Observable<Student[]>{
        console.log(an)
        return this.http.get<Student[]>(this.baseUrlStudents + "/" + an); 
      }    

   
    sendMail(mail: Mail): any {
      throw new Error("Method not implemented.");
    }
    addUser( user:User)
      {
        if(user.type == "Student")
        {
          let bodyStudent = JSON.stringify(
            {
              nume: user.nume,
              prenume: user.prenume,
              email: user.email,
              cnp: user.cnp,
              nrMatricol: user.numarMatricol,
              username: user.username,
              telefon: user.telefon,
              initiale: user.initiale,
              
            });
          console.log(bodyStudent);

          return this.http.post<User>(this.baseURL+"Students",
            bodyStudent,
            {
            headers: new HttpHeaders(
              {'Content-Type' : 'application/json'}
            )
          });
        }
        else
        {
          let body = JSON.stringify(
            {
              nume: user.nume,
              prenume: user.prenume,
              email: user.email,
              username: user.username,
              numartelefon: user.telefon
            });
          console.log(body);

          return this.http.post<User>(this.baseURL+user.type+"s",
            body,
            {
            headers: new HttpHeaders(
              {'Content-Type' : 'application/json'}
            )
          });
        }
    }

    deleteStudent( username: string){
      return this.http.delete(this.baseURL+"Students/" + username )
      {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )
      };
    }

    deleteTeacher( username: string){
      return this.http.delete(this.baseURL+"Teachers/" + username )
      {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )
      };
    }

    updateStudent( student: Student){
      console.log(student.initialaParinte + " " + student.numarTelefon + " ")
      let bodyStudent = JSON.stringify(
        {
          username: student.username,
          nume: student.nume,
          prenume: student.prenume,
          InitialaParinte: student.initialaParinte,
          type: student.type,
          NumarTelefon: student.numarTelefon,
          cnp: student.cnp,
          Generatie: student.generatie,
          An: student.an,
          email: student.email,
          numarMatricol: student.numarMatricol,
          salt: student.salt,
          password: student.password
        }
        );
      console.log(bodyStudent);

      return this.http.put<Student>(this.baseURL+"Students/" + student.username,
        bodyStudent,
        {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )
      });
    }

    updateTeacher( teacher: Teacher){
      let bodyStudent = JSON.stringify(
        {
          username: teacher.username,
          nume: teacher.nume,
          prenume: teacher.prenume,
          type: teacher.type,
          NumarTelefon: teacher.numarTelefon,
          email: teacher.email,
          salt: teacher.salt,
          password: teacher.password
        }
        );
      console.log(bodyStudent);

      return this.http.put<Teacher>(this.baseURL+"Teachers/" + teacher.username,
        bodyStudent,
        {
        headers: new HttpHeaders(
          {'Content-Type' : 'application/json'}
        )
      });
    }

}

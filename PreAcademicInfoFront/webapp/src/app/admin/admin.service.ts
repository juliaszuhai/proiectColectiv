import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

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
  


  baseURL = 'http://localhost:53087/api/';

  constructor(private http: HttpClient,
    private router: Router) { }
   
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
}

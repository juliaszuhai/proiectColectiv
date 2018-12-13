import { Component, OnInit } from '@angular/core';
import {GradeData, StudentData, StudentService} from "../student.service";
import {Router} from "@angular/router";

import {MatTableDataSource, Sort} from "@angular/material";
import {animate, state, style, transition, trigger} from "@angular/animations";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class HomeComponent implements OnInit{

  semestre=[{value: '1', viewValue: 'Semsetrul 1'},
    {value: '2', viewValue: 'Semestrul 2'},
    {value: '3', viewValue: 'Semestrul 3'},
    {value:'4', viewValue:'Semestrul 4'},
    {value:'5', viewValue:'Semestrul 5'},
    {value:'6', viewValue:'Semestrul 6'}
  ];
  ani = [
    {value: '1', viewValue: 'Anul 1'},
    {value: '2', viewValue: 'Anul 2'},
    {value: '3', viewValue: 'Anul 3'},
  ];

  datalist: GradeData[] = [
    {
      an:'3',
      semestru:'1',
      numeMaterie:'LFTC',
      nota:'10',
      nrCredite:'6',
      dataPromovarii:'10.10.2010',
      descriere:'cea mai grea materie',
      codMaterie:'MLE11111'
    },
    {
      an:'3',
      semestru:'1',
      numeMaterie:'PDP',
      nota:'10',
      nrCredite:'6',
      dataPromovarii:'10.10.2030',
      descriere:'de fapt asta e cea mai grea materie',
      codMaterie:'MLE9865'
    },
    {
      an:'3',
      semestru:'1',
      numeMaterie:'Mobile',
      nota:'9',
      nrCredite:'6',
      dataPromovarii:'10.10.2010',
      descriere:'cel mai hater prof',
      codMaterie:'MLE1444'
    }
  ];

  dataSource:GradeData[]=this.datalist;
  columnsToDisplay = ['an', 'semestru', 'numeMaterie', 'nota', 'nrCredite'];
  expandedElement: GradeData;

  constructor(private studentService:StudentService, private router: Router) { }

  ngOnInit(): void {
    this.getStudent();
  }

  getStudent()
  {var username=localStorage.getItem("username");
    this.studentService.getStudent(username).subscribe(
      data => {
        console.log(data);
      });
  }


  sortList(sort: Sort) {
    const data = this.dataSource.slice();
    if (!sort.active || sort.direction === '') {
      this.dataSource = data;
      return;
    }

    this.dataSource = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'an':
          return compare(a.an, b.an, isAsc);
        case 'semestru':
          return compare(a.semestru, b.semestru, isAsc);
        case 'numeMaterie':
          return compare(a.numeMaterie, b.numeMaterie, isAsc);
        case 'nota':
          return compare(a.nota, b.nota, isAsc);
        case 'nrCredite':
          return compare(a.nrCredite, b.nrCredite, isAsc);
        default:
          return 0;
      }
    });
  }

  onChangeAn(event:any) {
    //console.log(event.value);
    let an=event.value;
    this.dataSource=this.datalist.filter(grade=> grade.an == an);
    //console.log(this.dataSource);

  }

  onChangeSemestru(event:any) {
    let semestru=event.value;
    this.dataSource=this.datalist.filter(grade=> grade.semestru == semestru);
    //console.log(this.dataSource);
  }


}

  function compare(a: number | string, b: number | string, isAsc: boolean) {
      return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }







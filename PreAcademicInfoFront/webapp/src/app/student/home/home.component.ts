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

export class HomeComponent {

  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['an','semestru','numeMaterie', 'nota', 'nrCredite'];
  expandedElement: GradeData;

}

const ELEMENT_DATA: GradeData[] = [
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

function sortData(sort: Sort) {
  const data = this.ELEMENT_DATA.slice();
  if (!sort.active || sort.direction === '') {
    this.ELEMENT_DATA = data;
    return;
  }

  this.sortedData = data.sort((a, b) => {
    const isAsc = sort.direction === 'asc';
    switch (sort.active) {
      case 'numeMaterie': return compare(a.numeMaterie, b.numeMaterie, isAsc);
      case 'nota': return compare(a.nota, b.nota, isAsc);
      case 'nrCredite': return compare(a.nrCredite, b.nrCredite, isAsc);
      case 'codMaterie': return compare(a.codMaterie, b.codMaterie, isAsc);
      default: return 0;
    }
  });
}

function compare(a: number | string, b: number | string, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}

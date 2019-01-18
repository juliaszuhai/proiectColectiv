import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-formula',
  templateUrl: './formula.component.html',
  styleUrls: ['./formula.component.scss']
})
export class FormulaComponent implements OnInit {

  constructor() { }
  selectedMaterie: string;

  checkedExamen = false;
  checkedPartial = false;
  checkedLaborator = false;
  checkedExamPr = false;
  checkedBonus = false;

  percentageExam: number;
  percentagePartial: number;
  percentageLab: number;
  percentageExamPr: number;
  puncteBonus: number;

  nrLab: number;
  checked1 = false;
  checked2 = false;
  nrLabs = [];

  materii = [
    {value: '0', viewValue: 'LFTC'},
    {value: '1', viewValue: 'PPD'},
    {value: '2', viewValue: 'ASC'},
    {value:'3', viewValue:'WEB'},
    {value:'4', viewValue:'Proiect Colectiv'},
    {value:'5', viewValue:'Mobile'}
    ];

  ngOnInit() {
  }

  createArray(){
    this.nrLabs = Array.from(new Array(this.nrLab),(val,index)=>index+1);
    return this.nrLabs;
  }

  isMoreThanOneMaterii() {
    if( this.materii.length>1)
      return true;
    else
      return false;
  }

}

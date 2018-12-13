import { Component, OnInit } from '@angular/core';
import {DisciplineData, SpecializareData, StudentService} from "../student.service";
import {Router} from "@angular/router";


const DISCIPLINE_DATA: DisciplineData[] = [
  {An:"1",semestru:"1", nume:"Fundamentele Programarii", codMaterie:"123455", facultativ:false,obligatoriu:true,optional:false, locuriDisponibile:200, nrCredite:"6",locuriOcupate:200},
  {An:"1",semestru:"2", nume:"Materie cu Gabi", codMaterie:"123455", facultativ:true,obligatoriu:false,optional:false, locuriDisponibile:200, nrCredite:"1",locuriOcupate:10}
  ];


@Component({
  selector: 'app-disciplines',
  templateUrl: './disciplines.component.html',
  styleUrls: ['./disciplines.component.scss']
})
export class DisciplinesComponent implements OnInit {

  constructor(private studentService:StudentService, private router: Router) { }


  columnsToDisplay1=['Check','An', 'semestru', 'nume', 'nrCredite', 'locuri'];
  columnsToDisplay=['An', 'semestru', 'nume', 'nrCredite'];
  dataSource1 = DISCIPLINE_DATA;
  specializariList:SpecializareData[];
  materiiSelectate:DisciplineData[]=[];
  showTable:boolean;

  semestre = [
    {value: '0', viewValue: 'Semsetrul 1'},
    {value: '1', viewValue: 'Semestrul 2'},
    {value: '2', viewValue: 'Semestrul 3'},
    {value:'3', viewValue:'Semestrul 4'},
    {value:'4', viewValue:'Semestrul 5'},
    {value:'5', viewValue:'Semestrul 6'}
    ];
  ani = [
    {value: '0', viewValue: 'Anul 1'},
    {value: '1', viewValue: 'Anul 2'},
    {value: '2', viewValue: 'Anul 3'},
  ];
  departamente=[
    {value: '0', viewValue: 'Facultatea de Matematica si Informatica'},
    {value:'1', viewValue: 'Facultatea de Litere'}
  ];
  displayedColumnsFooter=['Total numar credite:', 'Suma'];

  isDisabled(element)
  {
    if(element.obligatoriu==true)
    {
      var alreadyInArray= this.materiiSelectate.find(x => x.nume == element.nume);
      if(alreadyInArray == undefined) {
        this.materiiSelectate.push(element);
      }
      return true;}
    else
      return false;
  }

  ngOnInit() {
    this.studentService.getSpecializari().subscribe(
      (data) => {
        this.specializariList = data;

    console.log(data)},
      error => {

        console.log(error);

      });
  }

  submitContract() {

    this.showTable=true;
    console.log(this.materiiSelectate);

  }

  isMoreThanOne() {
    if( this.departamente.length>1)
      return true;
    else
      return false;
  }

  AddSelected(e, x) {
    if(e.checked){
      this.materiiSelectate.push(x);
    }
  }

  getTotalCredite() {

      return this.materiiSelectate.map(t => parseInt(t.nrCredite, 10)).reduce((acc, value) => acc + value, 0);

  }

  btnClick() {
    this.router.navigate(['/contracte']);
  }
}

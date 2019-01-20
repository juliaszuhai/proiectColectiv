import { Component, OnInit } from '@angular/core';
import {DisciplineData, SpecializareData, StudentService} from "../student.service";
import {Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material";


@Component({
  selector: 'app-disciplines',
  templateUrl: './disciplines.component.html',
  styleUrls: ['./disciplines.component.scss']
})
export class DisciplinesComponent implements OnInit {

  constructor(private studentService:StudentService, private router: Router) { }


  columnsToDisplay1=['Check','An', 'semestru','nume','nrCredite','type','locuri'];
  columnsToDisplay=['An', 'semestru', 'nume', 'nrCredite'];
  dataSource1:MatTableDataSource<DisciplineData>;
  specializari=[];
  materiiSelectate:DisciplineData[]=[];
  showTable:boolean;
  selectedSpecializare="";
  selectedAn="0";
  selectedSemestru="0";
  show=false;

  semestre = [
    {value: '1', viewValue: 'Semsetrul 1'},
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
  displayedColumnsFooter=['Total numar credite:', 'Suma'];



  ngOnInit() {
    this.showTable=false;
    var username=localStorage.getItem("username");
    this.studentService.getSpecializari(username).subscribe(
      (data) => {
        for (var _i = 0; _i < data.length; _i++) {
          //console.log(data[_i]);
          this.specializari.push({value: _i.toString(), viewValue: data[_i]});
        }},
      error => {
        console.log(error);
      });
  }

  submitContract() {
    this.showTable=true;
    console.log(this.materiiSelectate);
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
    console.log("clicked");
    this.studentService.saveContract(this.materiiSelectate).subscribe();

  }

  onChangeSpecializare(e) {
    this.show=true;
    this.selectedSpecializare=this.specializari[e.value].viewValue;
    this.studentService.getAvailableDisciplines(this.selectedSpecializare,this.selectedAn,this.selectedSemestru).subscribe(
      data => {
        this.dataSource1 = new MatTableDataSource(data);
      }
    );
    console.log(this.dataSource1);
  }

  onChangeAn(e){
    console.log(e.value);
    this.selectedAn=e.value;
    this.studentService.getAvailableDisciplines(this.selectedSpecializare,this.selectedAn,this.selectedSemestru).subscribe(
      data =>
      {this.dataSource1 = new MatTableDataSource(data);}
    );
  }

  onChangeSemestru(e){
    this.selectedSemestru=e.value;
    this.studentService.getAvailableDisciplines(this.selectedSpecializare,this.selectedAn,this.selectedSemestru).subscribe(
      data =>
      {this.dataSource1 = new MatTableDataSource(data);}
    );
  }
}

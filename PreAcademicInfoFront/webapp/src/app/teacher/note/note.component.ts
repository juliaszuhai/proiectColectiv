import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { Moment } from 'moment';
import * as moment from 'moment';
import { MatDatepicker } from '@angular/material';
import { MatRadioChange } from '@angular/material/radio';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements  OnInit, AfterViewInit {


  constructor() { }
  @ViewChild(MatDatepicker) myDatepicker: MatDatepicker<Moment>;
  isValidMoment: boolean = false;
  selectedMaterie: string;
  selectedGrupa: string;
  isExamenFinal: boolean = false;
  isLaborator: boolean = false;
  isSeminar: boolean = false;
  isBonus: boolean = false;
  choosedOption: string;

  materii = [
    {value: '0', viewValue: 'LFTC'},
    {value: '1', viewValue: 'PPD'},
    {value: '2', viewValue: 'ASC'},
    {value:'3', viewValue:'WEB'},
    {value:'4', viewValue:'Proiect Colectiv'},
    {value:'5', viewValue:'Mobile'}
    ];
  grupe = [
    {value: '0', viewValue: '931'},
    {value: '1', viewValue: '932'},
    {value: '2', viewValue: '933'},
    {value: '3', viewValue: '934'},
    {value: '4', viewValue: '935'},
    {value: '5', viewValue: '936'},
  ];
  
  optiuniNote=['Examen final', 'Laborator', 'Seminar', 'Bonus'];

  ngOnInit() {
  }

  radioChange(event: MatRadioChange) {
    if(event.value == 'Examen final'){this.isExamenFinal = true;}
    if(event.value == 'Laborator'){this.isLaborator = true; }
    if(event.value == 'Seminar'){this.isSeminar = true;}
    if(event.value == 'Bonus') {this.isBonus = true;}
  }

  ngAfterViewInit(){
    this.myDatepicker._selectedChanged.subscribe(
      (newDate: Moment) => {
        this.isValidMoment = moment.isMoment(newDate);
      },
      (error) => {
        throw Error(error);
      }
    );
  }


  isMoreThanOneMaterii() {
    if( this.materii.length>1)
      return true;
    else
      return false;
  }

  isMoreThanOneGrupe() {
    if( this.grupe.length>1)
      return true;
    else
      return false;
  }

  showRadioButtons(){
    if(this.isValidMoment==true && this.selectedMaterie!=null && this.selectedGrupa!=null)
      return true;
    return false;
  }

}

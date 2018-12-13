import { Component, OnInit } from '@angular/core';
import { MatRadioChange } from '@angular/material/radio';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements  OnInit {


  constructor() { }
  selectedMaterie: string;
  selectedGrupa: string;
  isExamenFinal: boolean = false;
  isLaborator: boolean = false;
  isSeminar: boolean = false;
  isBonus: boolean = false;
  choosedOption: string;
  myModel: boolean = false;

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
    if(this.selectedMaterie!=null && this.selectedGrupa!=null)
      return true;
    return false;
  }

}

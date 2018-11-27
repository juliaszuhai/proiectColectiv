import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  constructor() { }

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
  
  isDisabled(element)
  {
    if( element==true)
      return true;
    else
      return false;

  }

  ngOnInit() {
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

}

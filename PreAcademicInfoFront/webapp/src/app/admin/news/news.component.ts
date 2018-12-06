import { Component, OnInit } from '@angular/core';
import { DisciplineData, AdminService, Mail } from '../admin.service';
import { Router } from '@angular/router';

const DISCIPLINE_DATA: DisciplineData[] = [
  {An:"1",semestru:"1", nume:"Fundamentele Programarii", codMaterie:"123455", facultativ:false,obligatoriu:true,optional:false, locuriDisponibile:200, nrCredite:"6",locuriOcupate:200},
  {An:"1",semestru:"2", nume:"Materie cu Gabi", codMaterie:"123455", facultativ:true,obligatoriu:false,optional:false, locuriDisponibile:200, nrCredite:"1",locuriOcupate:10}
  ];
  
@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {

  mail : Mail;
  selected : boolean;

  ngOnInit(): void {
    
  }

  constructor(private studentService:AdminService, private router: Router) { 
    this.mail = {
      titlu : '',
      mesaj : ''
    }
  }

  onChange(event:any) {
    let param = event.value;
    if (param != '')
    {
      this.selected = true;
    }

  }


  columnsToDisplay1=['Check','An', 'semestru', 'nume', 'nrCredite', 'locuri'];
  dataSource1 = DISCIPLINE_DATA;

  grupe = [
    {value: '0', viewValue: '931'},
    {value: '0', viewValue: '932'},
    {value: '0', viewValue: '933'},
    ];
  ani = [
    {value: '0', viewValue: 'Anul 1'},
    {value: '1', viewValue: 'Anul 2'},
    {value: '2', viewValue: 'Anul 3'},
  ];
  departamente=[
    {value: '0', viewValue: 'Matematica'},
    {value:'1', viewValue: 'Informatica'}
  ];
  specializari=[
    {value: '0', viewValue: 'Informatica engleza'},
    {value:'1', viewValue: 'Informatica romana'},
    {value: '2', viewValue: 'Informatica germana'},
    {value:'3', viewValue: 'Informatica maghiara'}
  ];
}

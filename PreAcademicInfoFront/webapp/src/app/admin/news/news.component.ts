import { Component, OnInit } from '@angular/core';
import { DisciplineData, AdminService, MailData } from '../admin.service';
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

  mail : MailData;
  selected : boolean;

  grupe = [
    {value: '931', viewValue: '931'},
    {value: '932', viewValue: '932'},
    {value: '933', viewValue: '933'},
    ];
  ani = [
    {value: '1', viewValue: 'Anul 1'},
    {value: '2', viewValue: 'Anul 2'},
    {value: '3', viewValue: 'Anul 3'},
  ];
  departamente=[
    {value: 'Matematica', viewValue: 'Matematica'},
    {value:'Informatica', viewValue: 'Informatica'}
  ];
  specializari=[
    {value: 'Informatica engleza', viewValue: 'Informatica engleza'},
    {value:'Informatica romana', viewValue: 'Informatica romana'},
    {value: 'Informatica germana', viewValue: 'Informatica germana'},
    {value:'Informatica maghiara', viewValue: 'Informatica maghiara'}
  ];
  
  ngOnInit(): void {
    //load materile predate de un teacher
    this.adminService.getDepartamente()
    .subscribe(data => 
      {
        for (var _i = 0; _i < data.length; _i++)
        {
          this.departamente.push({value:data[_i], viewValue: data[_i]});
        }
      }
      );
  }

  constructor(private adminService:AdminService, private router: Router) { 
    this.mail = {
      titlu : '',
      mesaj : '',
      departament:'',
      specializare:'',
      an: '',
      grupa: ''
    }
  }

  onChange(event:any) {
    let param = event.value;
    if (param != '')
    {
      this.selected = true;
    }
    this.mail.departament = param
    this.adminService.getSpecializari(this.mail.specializare)
    .subscribe(data => 
      {
        for (var _i = 0; _i < data.length; _i++)
        {
          this.specializari.push({value:data[_i], viewValue: data[_i]});
        }
      }
      );
    console.log("Departament:",this.mail.departament)

  }
  onSpecializareChange(event:any){
    let param = event.value;
    this.mail.specializare = param;
    console.log("Specializare:",this.mail.specializare);
  }
  onAnChange(event:any) {
    let param = event.value;
    this.mail.an = param;
    this.adminService.getGrupe(this.mail.an)
    .subscribe(data => 
      {
        for (var _i = 0; _i < data.length; _i++)
        {
          this.grupe.push({value:data[_i], viewValue: data[_i]});
        }
      }
    );
    console.log("An:",this.mail.an);
  }
  onGrupaChange(event:any) {
    let param = event.value;
    this.mail.grupa = param;
    
    console.log("Grupa:",this.mail.grupa);
  }
  submitForm(){
    this.adminService.sendMail(this.mail);
  }


  columnsToDisplay1=['Check','An', 'semestru', 'nume', 'nrCredite', 'locuri'];
  dataSource1 = DISCIPLINE_DATA;

 
}

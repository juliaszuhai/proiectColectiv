import { Component, OnInit } from '@angular/core';
import { TeacherService } from '../teacher.service';
import { ToastrManager } from 'ng6-toastr-notifications';

@Component({
  selector: 'app-formula',
  templateUrl: './formula.component.html',
  styleUrls: ['./formula.component.scss']
})
export class FormulaComponent implements OnInit {

  constructor(private teacherService: TeacherService,public toastr: ToastrManager) {
    this.notEvenPercetageLabs=[];
   }

  ngOnInit() {
    this.teacherService.getMaterii(localStorage.getItem('username'))
    .subscribe(data => 
      { 
        for (var _i = 0; _i < data.length; _i++)
        {
          this.materii.push({value: _i.toString(), viewValue: data[_i]});
        }
      }
      );
    }

  selectedMaterie: string;

  checkedExamen = false;
  checkedPartial = false;
  checkedLaborator = false;
  checkedSeminar = false;
  checkedBonus = false;
  submitted:boolean = false;
  percentageLabUnic:number = 0;
  percentageExam: number = 0;
  percentagePartial: number= 0;
  percentageSeminar: number= 0;
  puncteBonus: number= 0;


  nrLab: number;
  checked1 = false;
  checked2 = false;
  nrLabs = [];
  notEvenPercetageLabs=[];
  labPrecentageInner=[];
  percentageLabOuter:number= 0;
  evenPercentageLab:number;

  materii = [];

  
  updateEvenPercentage()
  {
    this.evenPercentageLab = this.percentageLabOuter / this.nrLab;
  }
  createArray(){
    this.nrLabs = Array.from(new Array(this.nrLab),(val,index)=>index+1);
    console.log("nr labs:"+this.nrLab);
    if(this.notEvenPercetageLabs.length == 0)
    for(var _i = 0;_i < this.nrLab; _i++)
    {
      this.notEvenPercetageLabs.push(0);
    }
    return this.nrLabs;
  }

  isMoreThanOneMaterii() {
    if( this.materii.length>1)
      return true;
    else
      return false;
  }
  noteFinale(event)
  {
    console.log(this.submitted);
    if(this.submitted == true)
    {
      this.teacherService.ComputeNotaFinala(this.selectedMaterie).subscribe(data => {
        this.toastr.successToastr('Notele finale au fost calculate si salvate la loc sigur',"Relax!");
      });
    }
  }
  submitProcentaje($event)
  {
    let s:number = 0;
    if(this.checkedExamen != true){this.percentageExam = 0;}
    else{s += this.percentageExam;}
    if(this.checkedPartial != true){this.percentagePartial = 0;}
    else{s += this.percentagePartial;}
    if(this.checkedLaborator != true){this.percentageLabOuter = 0;}
    if(this.checkedSeminar != true){this.percentageSeminar = 0;}
    else{s += this.percentageSeminar;}
    if(this.checkedBonus != true){this.puncteBonus = 0;}

    if(s!=100-this.percentageLabOuter)
    {
      this.toastr.errorToastr('Suma procentajelor nu este 100%, ci:'+s+this.percentageLabOuter+"%", 'Oops!');
    }
    else{

    if(this.checked1 == true)
    {
      for(var _i = 0;_i < this.nrLab; _i++)
      {
        this.labPrecentageInner.push(this.evenPercentageLab);
      }
      console.log(this.labPrecentageInner);
      this.teacherService.PostProcentaje(this.selectedMaterie,this.percentageExam,this.percentagePartial,
        this.percentageSeminar,this.puncteBonus,this.percentageLabOuter,this.labPrecentageInner).subscribe(data => 
          { 
              this.submitted = true;
             this.toastr.successToastr('procentele s-au trimis cu succes',"Felicitari!");
          }
          );
    }
    else{
      let sl:number = 0;
      for(var _i = 0;_i < this.nrLab; _i++)
      {
        sl += this.notEvenPercetageLabs[_i];
      }
      if(100-sl == s)
      {
        
        console.log(this.submitted);
        this.teacherService.PostProcentaje(this.selectedMaterie,this.percentageExam,this.percentagePartial,
          this.percentageSeminar,this.puncteBonus,this.percentageLabOuter,this.notEvenPercetageLabs).subscribe(data => 
            { 
              this.submitted = true;
                this.toastr.successToastr('procentele s-au trimis cu succes',"Felicitari!");
            });
        
      }
      else{
        this.toastr.errorToastr('Suma procentajelor laboratoarelor nu este 100%, ci:'+sl+"%", 'Oops!');
      }
    }
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { TeacherService } from '../teacher.service';

@Component({
  selector: 'app-formula',
  templateUrl: './formula.component.html',
  styleUrls: ['./formula.component.scss']
})
export class FormulaComponent implements OnInit {

  constructor(private teacherService: TeacherService) {
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

  percentageLabUnic:number;
  percentageExam: number;
  percentagePartial: number;
  percentageSeminar: number;
  puncteBonus: number;


  nrLab: number;
  checked1 = false;
  checked2 = false;
  nrLabs = [];
  notEvenPercetageLabs=[];
  labPrecentageInner=[];
  percentageLabOuter:number;
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

  submit($event)
  {
    
    if(this.checkedExamen != true)
    {
      this.percentageExam = 0;
    }
    if(this.checkedPartial != true)
    {
      this.percentagePartial = 0;
    }
    if(this.checkedLaborator != true)
    {
      this.percentageLabOuter = 0;
    }
    if(this.checkedSeminar != true)
    {
      this.percentageSeminar = 0;
    }
    if(this.checkedBonus != true)
    {
      this.puncteBonus = 0;
    }
    if(this.checked1 == true)
    {
      for(var _i = 0;_i < this.nrLab; _i++)
      {
        this.labPrecentageInner.push(this.evenPercentageLab);
      }
      console.log(this.labPrecentageInner);
      this.teacherService.PostProcentaje(this.selectedMaterie,this.percentageExam,this.percentagePartial,
        this.percentageSeminar,this.puncteBonus,this.percentageLabOuter,this.labPrecentageInner);
    }
    else{
      console.log(this.notEvenPercetageLabs);
      this.teacherService.PostProcentaje(this.selectedMaterie,this.percentageExam,this.percentagePartial,
        this.percentageSeminar,this.puncteBonus,this.percentageLabOuter,this.notEvenPercetageLabs);
    }


  }

}

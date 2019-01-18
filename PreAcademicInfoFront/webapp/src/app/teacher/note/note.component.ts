import { Component, OnInit } from '@angular/core';
import { MatRadioChange } from '@angular/material/radio';
import { TeacherService, StudentData } from '../teacher.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements  OnInit {


  constructor(private teacherService: TeacherService) { }
  selectedMaterie: string;
  selectedGrupa: string;
  isExamenFinal: boolean = false;
  isLaborator: boolean = false;
  isSeminar: boolean = false;
  isBonus: boolean = false;
  choosedOption: string;
  myModel: boolean = false;

  grupe = [];
  materii = [];
  optiuniNote=['Examen final', 'Laborator', 'Seminar', 'Bonus'];

  ngOnInit() {
    //load materile predate de un teacher
    this.teacherService.getMaterii(localStorage.getItem('username'))
    .subscribe(data => 
      { console.log(data);
        for (var _i = 0; _i < data.length; _i++)
        {
          this.grupe.push({value: _i.toString(), viewValue: data[_i]});
        }
      }
      );

      //load grupele care au studenti care au materia curent selectata
      this.teacherService.getGrupe(this.selectedMaterie)
    .subscribe(data => 
      { console.log(data);
        for (var _i = 0; _i < data.length; _i++)
        {
          this.materii.push({value: _i.toString(), viewValue: data[_i]});
        }
      }
      );
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

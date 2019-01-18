import { Component, OnInit, AfterViewInit, ViewChild, Input } from '@angular/core';
import { TeacherService, StudentData } from '../teacher.service';
import { Moment } from 'moment';
import * as moment from 'moment';
import { MatDatepicker } from '@angular/material';


@Component({
  selector: 'app-note-finale-date-picker',
  templateUrl: './note-finale-date-picker.component.html',
  styleUrls: ['./note-finale-date-picker.component.scss']
})

export class NoteFinaleDatePickerComponent implements OnInit , AfterViewInit {

  @ViewChild(MatDatepicker) myDatepicker: MatDatepicker<Moment>;

  @Input() materie: string;
  @Input() grupa: string;
  @Input() tipNota: string;

  isValidMoment: boolean = false;
  columnsToDisplay = ['nrMatricol','nume','nota', 'data'];
  grade: string;
  choosedDate: string;
  public students = [];

  constructor(private teacherService: TeacherService){ }

  ngOnInit() {
    this.teacherService.getStudents(this.materie, this.grupa, this.tipNota)
        .subscribe(data => this.students = data)
  }
  ngAfterViewInit(){
    this.myDatepicker._selectedChanged.subscribe(
      (newDate: Moment) => {
        this.isValidMoment = moment.isMoment(newDate);
        this.choosedDate = moment(newDate).format("DD/MM/YYYY");
        console.log(this.choosedDate);
      },
      (error) => {
        throw Error(error);
      }
    );
  }

  saveGrade(event,elem){
    //save the grade into DB on focusout event
    this.grade=event.target.value;
    console.log(this.grade);
    if(this.choosedDate != "")
    {
      // this.teacherService.PostGrade(elem.username, this.grade, this.choosedDate,this.materie,this.tipNota).subscribe(
      //   data => {
      //   console.log(data);
      // });

      this.grade = "";
      this.choosedDate = "";
    }
  }


}

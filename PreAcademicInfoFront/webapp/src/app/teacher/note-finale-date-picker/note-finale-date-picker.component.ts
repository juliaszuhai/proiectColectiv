import { Component, OnInit, AfterViewInit, ViewChild, Input } from '@angular/core';
import { TeacherService, StudentData } from '../teacher.service';
import { Moment } from 'moment';
import * as moment from 'moment';
import { MatDatepicker } from '@angular/material';
import { ToastrManager } from 'ng6-toastr-notifications';

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
  choosedDate: string = null;
  public students = [];

  constructor(private teacherService: TeacherService,public toastr: ToastrManager){ }

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
    console.log(this.choosedDate);
    if(this.choosedDate !== null)
    {
      console.log("len of grades" + elem.grades.len);
      if(elem.grades.length > 0)
      {
        this.teacherService.PostGrade(elem.username, this.grade, this.choosedDate,this.materie,this.tipNota,elem.grades[0]["id"]).subscribe(
          data => {
          console.log(data);
        });
      }
      else
      {
        this.teacherService.PostGrade(elem.username, this.grade, this.choosedDate,this.materie,this.tipNota,"").subscribe(
          data => {
          console.log(data);
        });
      }

      this.grade = null;
      this.choosedDate = null;
    }
    else
    {
      this.toastr.warningToastr('Selecteaza data inainte de a completa notele', 'Alert!');
      console.log("baga ba o dataaaaaaaa baaaaa");
    }
  }


}

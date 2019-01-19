import { Component, OnInit } from '@angular/core';
import { ToastrManager } from 'ng6-toastr-notifications';

@Component({
  selector: 'app-teacher-view',
  templateUrl: './teacher-view.component.html',
  styleUrls: ['./teacher-view.component.scss']
})
export class TeacherViewComponent implements OnInit {

  constructor(public toastr: ToastrManager) {

   }
   
  card:boolean =true;
  ngOnInit() {
    
  }

  hide()
  {
    this.card = false;
    this.toastr.successToastr('This is success toast.', 'Success!');
  }

}

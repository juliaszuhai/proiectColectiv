import { Component, OnInit } from '@angular/core';
import { TeacherData,StudentService } from "../student.service";
import { ToastrManager } from 'ng6-toastr-notifications';


@Component({
  selector: 'app-teacher-view',
  templateUrl: './teacher-view.component.html',
  styleUrls: ['./teacher-view.component.scss']
})
export class TeacherViewComponent implements OnInit {

  constructor(public toastr: ToastrManager,private studentService:StudentService) {

   }
   
  card:boolean =true;
  public teachers: TeacherData[];
  // teachers: TeacherData[] = [
  //   {name:"Tzutzu",
  //   url: "https://www.scrisulfacebine.ro/wp-content/uploads/2018/02/dan-mircea-suciu.jpg",
  //   description:"Domenii de interes: Baze de date"},
  //   {name:"Tzutzu",
  //   url: "https://www.scrisulfacebine.ro/wp-content/uploads/2018/02/dan-mircea-suciu.jpg",
  //   description:"Domenii de interes: Baze de date"},
  //   {name:"Tzutzu",
  //   url: "https://www.scrisulfacebine.ro/wp-content/uploads/2018/02/dan-mircea-suciu.jpg",
  //   description:"Domenii de interes: Baze de date"},
  //   {name:"Iuliana Bocicor",
  //    url: "https://i1.rgstatic.net/ii/profile.image/325007529005070-1454499241433_Q512/Iuliana_Bocicor.jpg",
  //    description: "Domenii de interes:AI "},
  //   {name:"Iuliana Bocicor",
  //   url: "https://i1.rgstatic.net/ii/profile.image/325007529005070-1454499241433_Q512/Iuliana_Bocicor.jpg",
  //   description: "Domenii de interes:AI "},
  //   {name:"Radu Dragos",
  //   url: "http://www.cs.ubbcluj.ro/wp-content/uploads/Radu-Dragos.jpg",
  //   description: "Domenii de interes: Network "}
  // ];
  teacher: TeacherData;
  ngOnInit() {
    this.studentService.getTeachersDetails().subscribe(
      data =>
      {
        this.teachers = data;
        console.log(this.teachers);
      }
    );
  }

  hide()
  {
    this.card = false;
    //this.toastr.successToastr('This is success toast.', 'Success!');
  }

}
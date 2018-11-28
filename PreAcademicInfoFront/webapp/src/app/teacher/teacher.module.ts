import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoteComponent } from './note/note.component';
import { NavTeacherComponent } from './nav-teacher/nav-teacher.component';
import {RouterModule, Routes} from "@angular/router";
import {FormsModule} from "@angular/forms";
import {MaterialModule} from "../material";
import {HttpClientModule} from "@angular/common/http";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {BrowserModule} from "@angular/platform-browser";
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material';
import {MatMomentDateModule} from '@angular/material-moment-adapter';

const routes: Routes = [
  {path: 'teacher', component: NoteComponent},
];

@NgModule({
  declarations: [
    NoteComponent, 
    NavTeacherComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatMomentDateModule,
    HttpClientModule,
  ],
  //providers: [TeacherService],
  exports: [RouterModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,]
})
export class TeacherModule { }

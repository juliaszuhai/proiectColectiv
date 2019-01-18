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
import { NoteFinaleComponent } from './note-finale/note-finale.component';
import { NoteFinaleDatePickerComponent } from './note-finale-date-picker/note-finale-date-picker.component';
import { TeacherService } from './teacher.service';
import { MatSlideToggleModule } from '@angular/material';
import { FormulaComponent } from './formula/formula.component';
import {MatCardModule} from '@angular/material/card';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { ReactiveFormsModule} from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import { NoteLabTeacherComponent } from './note-lab-teacher/note-lab-teacher.component';

const routes: Routes = [
  {path: 'teacher', component: NoteComponent},
  {path: 'formula', component: FormulaComponent}
];

@NgModule({
  declarations: [
    NoteComponent, 
    NavTeacherComponent, NoteFinaleComponent, NoteFinaleDatePickerComponent, FormulaComponent, NoteLabTeacherComponent
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
    MatSlideToggleModule,
    MatCardModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    MatButtonModule,
    HttpClientModule,
  ],
  providers: [TeacherService],
  exports: [RouterModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,]
})
export class TeacherModule { }

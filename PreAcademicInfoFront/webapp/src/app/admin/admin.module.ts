import { NgModule } from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {FormsModule} from "@angular/forms";
import {MaterialModule} from "../material";
import {HttpClientModule} from "@angular/common/http";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {BrowserModule} from "@angular/platform-browser";
import {CrudstudentComponent} from "./crudstudent/crudstudent.component";
import {NavAdminComponent} from "./nav-admin/nav-admin.component";
import {AdminService} from "./admin.service";
import { TeachersListComponent } from './teachers-list/teachers-list.component';
import { StudentsListComponent } from './students-list/students-list.component';

const routes: Routes = [
  {path: 'crud', component: CrudstudentComponent},
  {path: 'teachers', component: TeachersListComponent},
  {path: 'students', component: StudentsListComponent},

];

@NgModule({
  declarations:[
    CrudstudentComponent,
    NavAdminComponent,
    TeachersListComponent,
    StudentsListComponent
  ],
  imports: [RouterModule.forRoot(routes),
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,],
  providers: [AdminService],
  exports: [RouterModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,]
})
export class AdminModule { }

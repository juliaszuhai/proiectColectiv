import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LoginComponent} from "./login/login.component";
import {AuthenticationServiceService} from "./authentication-service.service";
import {HomeComponent} from "../student/home/home.component";
import {RouterModule, Routes} from "@angular/router";
import {DisciplinesComponent} from "../student/disciplines/disciplines.component";
import {LoginGuardGuard} from "./login-guard.guard";
import {StudentService} from "../student/student.service";
import {FormsModule} from "@angular/forms";
import {MaterialModule} from "../material";
import {HttpClientModule} from "@angular/common/http";
import {BrowserModule} from "@angular/platform-browser";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

const routes: Routes = [
  {path: 'login', component: LoginComponent},
];

@NgModule({
  declarations:[
    LoginComponent,
  ],
  imports: [CommonModule,
    RouterModule.forRoot(routes),
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
  ],
  providers: [AuthenticationServiceService],
  exports: [RouterModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,]
})
export class SigninModule { }

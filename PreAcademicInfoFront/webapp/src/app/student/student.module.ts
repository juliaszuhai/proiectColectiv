import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LoginComponent} from "../signin/login/login.component";
import {HomeComponent} from "./home/home.component";
import {RouterModule, Routes} from "@angular/router";
import {DisciplinesComponent} from "./disciplines/disciplines.component";
import {LoginGuardGuard} from "../signin/login-guard.guard";
import {StudentService} from "./student.service";
import {AuthenticationServiceService} from "../signin/authentication-service.service";
import {FormsModule} from "@angular/forms";
import {MaterialModule} from "../material";
import {HttpClientModule} from "@angular/common/http";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {BrowserModule} from "@angular/platform-browser";
import {NavigationComponent} from "./navigation/navigation.component";
import { GuideComponent } from './guide/guide.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { NoteProvizoriiComponent } from './note-provizorii/note-provizorii.component';
import { NoteLabComponent } from './note-lab/note-lab.component';
import { PaymentsComponent } from './payments/payments.component';
const routes: Routes = [
  {path: 'home', component: HomeComponent, canActivate:[LoginGuardGuard]},
  {path: 'contracte', component: DisciplinesComponent, canActivate:[LoginGuardGuard]},
  {path: 'statistics', component: StatisticsComponent, canActivate:[LoginGuardGuard]},
  {path:  'note-provizorii', component:NoteProvizoriiComponent, canActivate:[LoginGuardGuard]},
  {path: 'note-lab',component:NoteLabComponent, canActivate:[LoginGuardGuard]},
  {path: 'guide', component: GuideComponent, canActivate:[LoginGuardGuard]},
  {path: 'taxe', component: PaymentsComponent}
];

@NgModule({
  declarations:[
    HomeComponent,
    DisciplinesComponent,
    NavigationComponent,
    GuideComponent,
    StatisticsComponent,
    NoteProvizoriiComponent,
    NoteLabComponent,
    PaymentsComponent
  ],
  imports: [RouterModule.forRoot(routes),
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,],
  providers: [StudentService,LoginGuardGuard,AuthenticationServiceService],
  exports: [RouterModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,]
})
export class StudentModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MaterialModule} from "./material";
import { LoginComponent } from './signin/login/login.component';
import { SigninModule } from './signin/signin.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import {LoginGuardGuard} from "./signin/login-guard.guard";
import { NavigationComponent } from './navigation/navigation.component';
import {
  MatButtonModule,
  MatCheckboxModule,
  MatMenuModule,
  MatSnackBarModule,
  MatTableModule,
  MatToolbarModule,
  MatDividerModule,
  MatGridListModule,
  MatOptionModule,
  MatSelectModule
  } from '@angular/material';
import {StudentService} from "./student.service";
import {AuthenticationServiceService} from "./signin/authentication-service.service";
import { DisciplinesComponent } from './disciplines/disciplines.component';


const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/login'}
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    NavigationComponent,
    DisciplinesComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    SigninModule,
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatMenuModule,
    MatSnackBarModule,
    MatTableModule,
    MatToolbarModule,
    MatDividerModule,
    MatGridListModule,
    MatOptionModule,
    MatSelectModule

  ],
  providers: [StudentService,LoginGuardGuard,AuthenticationServiceService],
  bootstrap: [AppComponent],
  exports:[MatButtonModule,
    MatCheckboxModule,
    MatMenuModule,
    MatSnackBarModule,
    MatTableModule,
    MatToolbarModule,
    MatDividerModule,
    MatGridListModule,
    MatOptionModule,
    MatSelectModule
   ]
})
export class AppModule { }

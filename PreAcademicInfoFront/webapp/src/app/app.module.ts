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
  MatToolbarModule
} from '@angular/material';


const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/login'}
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    SigninModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports:[MatButtonModule,
    MatCheckboxModule,
    MatMenuModule,
    MatToolbarModule,
    MatSnackBarModule]
})
export class AppModule { }

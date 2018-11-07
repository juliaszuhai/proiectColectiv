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

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/login'}
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
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
  bootstrap: [AppComponent]
})
export class AppModule { }

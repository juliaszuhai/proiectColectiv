import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MaterialModule} from "./material";
import { SigninModule } from './signin/signin.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import {LoginGuardGuard} from "./signin/login-guard.guard";
import {StudentService} from "./student/student.service";
import {AuthenticationServiceService} from "./signin/authentication-service.service";
import {StudentModule} from "./student/student.module";
import {AdminModule} from "./admin/admin.module";
import {TeacherModule} from "./teacher/teacher.module";
import { ToastrModule } from 'ng6-toastr-notifications';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/login'}
];

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    SigninModule,
    StudentModule,
    HttpClientModule,
    FormsModule,
    AdminModule,
    TeacherModule,
    ToastrModule.forRoot()
  ],
  providers: [StudentService,LoginGuardGuard,AuthenticationServiceService],
  bootstrap: [AppComponent],
  exports:[

   ]
})
export class AppModule { }

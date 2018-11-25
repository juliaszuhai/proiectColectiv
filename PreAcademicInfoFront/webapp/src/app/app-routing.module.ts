import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './signin/login/login.component';
import {HomeComponent} from "./student/home/home.component";
import {LoginGuardGuard} from "./signin/login-guard.guard";
import {NavigationComponent} from "./student/navigation/navigation.component";
import {DisciplinesComponent} from "./student/disciplines/disciplines.component";


const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/login'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

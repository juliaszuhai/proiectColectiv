import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './signin/login/login.component';
import {HomeComponent} from "./home/home.component";
import {LoginGuardGuard} from "./signin/login-guard.guard";
import {NavigationComponent} from "./navigation/navigation.component";
import {DisciplinesComponent} from "./disciplines/disciplines.component";

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/login'},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomeComponent, canActivate:[LoginGuardGuard]},
  {path: 'contracte', component: DisciplinesComponent, canActivate:[LoginGuardGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

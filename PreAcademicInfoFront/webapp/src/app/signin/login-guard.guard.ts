import { Injectable } from '@angular/core';
import {CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router} from '@angular/router';

import {AuthenticationServiceService} from "./authentication-service.service";
import {Observable} from "rxjs/internal/Observable";

@Injectable(
)
export class LoginGuardGuard implements CanActivate {

  constructor(private authService: AuthenticationServiceService, private router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (!this.authService.isLogged()) {
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }
  }






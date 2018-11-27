import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { AuthenticationServiceService } from 'src/app/signin/authentication-service.service';

@Component({
  selector: 'app-navigation-admin',
  templateUrl: './nav-admin.component.html',
  styleUrls: ['./nav-admin.component.scss'],
  providers: [AuthenticationServiceService]
})
export class NavAdminComponent implements OnInit {

  constructor(private authService: AuthenticationServiceService,
              private router: Router) { }

  ngOnInit() {
  }

  getFirstName() {
    return localStorage['firstName'];
  }

  public hasPermission(perm) {
    return this.authService.userHasPermission(perm);
  }

}


import { Component, OnInit } from '@angular/core';
import {AuthenticationServiceService} from "../signin/authentication-service.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
  providers: [AuthenticationServiceService]
})
export class NavigationComponent implements OnInit {

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

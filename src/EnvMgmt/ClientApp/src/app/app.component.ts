import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StateService } from './state-service';
import { AuthenticationService } from './services/authentication.service';
import { AuthenticationResultModel } from './models/authenticationresult';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  loginname: string
  _authResult: AuthenticationResultModel;
  authObj: AuthenticationResultModel = {
    authenticationType: '',
    isAuthenticated: '',
    name: '',
    domain: '',
    login: ''
  };

  constructor(public http: HttpClient, private _authService: AuthenticationService, public state: StateService) {
  }

  ngOnInit() {

    //this._authService.getUser().subscribe(resp => this.authObj = resp, error => this.errorMessage = error);
    this._authService.getUser().subscribe((data) => {
      this.authObj = data;
      //console.log(data);
      //console.log(this.authObj.login);
      if (this.authObj.login != "unknown") {
        this.loginname = this.authObj.login;
      }
    }, err => {
      console.log(err);
    });

    //console.log("Login: " + this.authObj.login);
    //console.log(this.authObj.login);
  }
}

import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { NgForm, FormsModule, Validators, FormControl } from '@angular/forms';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ApplicationsService } from '../../services/applications.service';
import { EnvironmentsService } from '../../services/environments.service';
import { EnvStatusService } from '../../services/envstatus.service';

import { Application } from '../../models/application';
import { Environment } from '../../models/environment';
import { AppEnvsByAppID } from '../../models/appenvsbyappid';
import { EnvStatus } from '../../models/envstatus';

import * as moment from 'moment';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'updateenvdashboard',
  templateUrl: './updateenvdashboard.component.html',
  styleUrls: ['./updateenvdashboard.component.css']
})

export class updateenvdashboard implements OnInit {
  errorMessage: any;
  ddlApplicationValue: string;
  applicationList: Application[];
  ddlEnvironmentValue: string;
  environmentList: AppEnvsByAppID[];
  modifiedtext: string;
  txtAppVersion: string;
  txtDBVersion: string;
  txtAppVersionFormControl = new FormControl('', [Validators.required]);
  matcher = new MyErrorStateMatcher();
  objEnvStatus: EnvStatus = {
    envStatusID: 0,
    appEnvID: 0,
    appVersion: '',
    databaseVersion: '',
    dateTimeDeployed: ''
  };

  constructor(public http: HttpClient, private _router: Router, private _avRoute: ActivatedRoute,
    private _applicationsService: ApplicationsService,
    private _environmentsService: EnvironmentsService,
    private _envStatusService: EnvStatusService) {   
   }

  ngOnInit() {
    this.getApplications();
    //this.getEnvironments();
    //this.appSelected = 0;
  }

  getApplications() {
    this._applicationsService.getApplications().subscribe(data => {
        this.applicationList = data;
    }
        , error => this.errorMessage = error)
  }

  onApplicationSelected(event) {
    this.getEnvironments(event.value); 
  }
  changeSelect() { console.log('made it'); }

  getEnvironments(val: any) {
    this._environmentsService.getEnvironmentsByAppId(val).subscribe(data => {
        this.environmentList = data;
    }, error => this.errorMessage = error)
  }


  save(f) {
    this.objEnvStatus.appEnvID = +this.ddlEnvironmentValue;
    this.objEnvStatus.appVersion = this.txtAppVersion;
    this.objEnvStatus.databaseVersion = this.txtDBVersion;
    this.objEnvStatus.dateTimeDeployed = moment().format('YYYY-MM-DD HH:mm:ss.mmm');
    //console.log("made it to save.");
    //console.log("Application: " + this.ddlApplicationValue);
    console.log("Environment: " + this.objEnvStatus.appEnvID);
    console.log("AppVersion: " + this.objEnvStatus.appVersion);
    console.log("DBVersion: " + this.objEnvStatus.databaseVersion);
    console.log("DateTime: " + this.objEnvStatus.dateTimeDeployed);
    //console.log(moment().format('YYYY-MM-DD HH:mm:ss.mmm'));
    //console.log("DateTime: " + moment("2016-01-17T:08:44:29+0100").format('MM/DD/YYYY'));
    //this._envStatusService.saveEnvStatus(this.objEnvStatus).subscribe((data) => {
      //if (data.status == 'success') {
        //this._router.navigate(['home']);
      //}
      //else {
      //  console.log("API Error: The Update API returned status of: failure.")
      //  throw new Error('The Update API call failed.');
      //}
    //}, error => this.errorMessage = error)

    this._envStatusService.saveEnvStatus(this.objEnvStatus)
      .subscribe((data) => {
        this._router.navigate(['/home']);
      }, error => this.errorMessage = error)

  }

  cancel() {
      this._router.navigate(['/home']);
  }
}


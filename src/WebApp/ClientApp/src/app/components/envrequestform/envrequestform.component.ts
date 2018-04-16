import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { NgForm, FormsModule, Validators, FormControl } from '@angular/forms';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ApplicationsService } from '../../services/applications.service';
import { AuthenticationService } from '../../services/authentication.service';
import { EnvironmentsService } from '../../services/environments.service';
import { EnvStatusService } from '../../services/envstatus.service';
import { ProjectTeamService } from '../../services/projectteam.service';

import { Application } from '../../models/application';
import { AppEnvsByAppID } from '../../models/appenvsbyappid';
import { Environment } from '../../models/environment';
import { EnvStatus } from '../../models/envstatus';
import { ProjectTeam } from '../../models/projectteam';

import * as moment from 'moment';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'env-request-form',
  templateUrl: './envrequestform.component.html',
  styleUrls: ['./envrequestform.component.css']
})

export class EnvRequestForm implements OnInit {
  errorMessage: any;
  txtRequestor: string;
  txtUsageOwner: string;
  releaseDatePicker: string;

  ddlProjectTeamValue: string;
  projectTeamList: ProjectTeam[];
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
    private _authenticationService: AuthenticationService,
    private _applicationsService: ApplicationsService,
    private _environmentsService: EnvironmentsService,
    private _envStatusService: EnvStatusService,
    private _projectTeamService: ProjectTeamService) {
   }

  ngOnInit() {
    this.getUserInfo();
    this.getProjectTeams();
    // this.getApplications(0);
  }

  getUserInfo() {
    this._authenticationService.getUser().subscribe((data) => {
      this.txtRequestor = data.name;
      this.txtUsageOwner = data.name;
    });
  }

  getProjectTeams() {
    this._projectTeamService.getProjectTeam().subscribe(data => {
      this.projectTeamList = data;
    }
      , error => this.errorMessage = error)
  }

  getApplications(val: number) {
    this._applicationsService.getApplications().subscribe((data) => {
      if (val === 0) {
        // console.log("loading ALL applications.");
        this.applicationList = data;
      } else {
        // console.log("loading FILTERED applications.");
        this.applicationList = data;
        let applicationFilteredList: Application[];
        applicationFilteredList = this.applicationList.filter((_application: Application) => _application.projectTeamID == val);
        this.applicationList = applicationFilteredList;

      }
    }
      , error => this.errorMessage = error)
  }

  onddlProjectTeamSelected(event) {
    this.getApplications(parseInt(event.value));
  }
  onApplicationSelected(event) {
    this.getEnvironments(event.value);
  }

  getEnvironments(val: any) {
    this._environmentsService.getEnvironmentsByAppId(val).subscribe(data => {
      this.environmentList = data;
    }, error => this.errorMessage = error)
  }

  dateChangeReleaseDate(val: any) {
    console.log(val);
  }


  save(f) {
    // console.log(f);
    console.log("txtRequestor: " + this.txtRequestor);
    console.log("txtUsageOwner: " + this.txtUsageOwner);
    console.log("releaseDatePicker: " + this.releaseDatePicker);
  }

  cancel() {
      this._router.navigate(['/home']);
  }
}


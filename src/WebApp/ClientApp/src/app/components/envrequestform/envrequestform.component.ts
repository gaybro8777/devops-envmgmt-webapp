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

import { MatSnackBar } from '@angular/material';

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

  startDatePicker: string;
  startDatePickerControl = new FormControl({ value: '', disabled: true }, [Validators.required]);
  startTimePicker: string;
  endDatePicker: string;
  endDatePickerControl = new FormControl({ value: '', disabled: true }, [Validators.required]);
  endTimePicker: string;

  constructor(public http: HttpClient, private _router: Router, private _avRoute: ActivatedRoute,
    private _authenticationService: AuthenticationService,
    private _applicationsService: ApplicationsService,
    private _environmentsService: EnvironmentsService,
    private _envStatusService: EnvStatusService,
    private _projectTeamService: ProjectTeamService,
    public snackBar: MatSnackBar) {
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
    this.releaseDatePicker = val;
  }

  dateChangeStartDate(val: any) {
    let startDT = moment(val);
    this.startDatePicker = startDT.format('YYYY-MM-DD');
  }
  dateChangeEndDate(val: any) {
    let startDT = moment(val);
    this.endDatePicker = startDT.format('YYYY-MM-DD');
  }

  onChangeStartTime(val: any) {
    let startTime = moment();
    startTime.hour(this.Convert12to24Hour(val.hour, val.meriden));
    startTime.minute(val.minute);
    this.startTimePicker = startTime.format('LT');
  }
  onChangeEndTime(val: any) {
    //console.log(val);
    let endTime = moment();
    endTime.hour(this.Convert12to24Hour(val.hour, val.meriden));
    //console.log(this.Convert12to24Hour(val.hour, val.meriden));
    endTime.minute(val.minute);
    
    //endTime.format(val.meriden.toLowerCase());
    // endTime.format('p');
    //console.log(endTime.format('LT'));
    this.endTimePicker = endTime.format('LT');
  }
  Convert12to24Hour(Hour: number, Meridiem: string): number {
    let calculated24Hour = Hour;
    //console.log("Meridiem: " + Meridiem);
   // console.log("Hour: " + Hour.toString());
    if (Meridiem == 'PM' && Hour < 12) {
      calculated24Hour = Hour + 12;
      //console.log("calculated24Hour: " + calculated24Hour.toString());
    }
    if (Meridiem == 'AM' && Hour == 12) {
      calculated24Hour = Hour - 12;
      //console.log("calculated24Hour12: " + calculated24Hour.toString());
    }
    //console.log("about to return: " + calculated24Hour.toString());
    return calculated24Hour;
  }



  save(f) {
    // console.log(f);
    this.snackBar.open("saving!", null, { duration: 500, });
    console.log("txtRequestor: " + this.txtRequestor);
    console.log("txtUsageOwner: " + this.txtUsageOwner);
    console.log("releaseDatePicker: " + this.releaseDatePicker);
    console.log("ddlProjectTeamValue: " + this.ddlProjectTeamValue);
    console.log("ddlApplicationValue: " + this.ddlApplicationValue);
    console.log("ddlEnvironmentValue: " + this.ddlEnvironmentValue);
    console.log("txtAppVersion: " + this.txtAppVersion);
    console.log("txtDBVersion: " + this.txtDBVersion);
    console.log("startDatePicker: " + this.startDatePicker);
    console.log("endDatePicker: " + this.endDatePicker);
    console.log("startTimePicker: " + this.startTimePicker);
    console.log("endTimePicker: " + this.endTimePicker);

  }

  cancel() {
      this._router.navigate(['/home']);
  }
}


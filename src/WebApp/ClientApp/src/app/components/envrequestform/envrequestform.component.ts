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
  selector: 'env-request-form',
  templateUrl: './envrequestform.component.html',
  styleUrls: ['./envrequestform.component.css']
})

export class EnvRequestForm implements OnInit {
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
    //this.getApplications();
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
    
  }

  cancel() {
      this._router.navigate(['/home']);
  }
}


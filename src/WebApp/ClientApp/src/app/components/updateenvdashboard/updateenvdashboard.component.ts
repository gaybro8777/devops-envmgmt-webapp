import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { NgForm, FormsModule, Validators, FormControl } from '@angular/forms';
import { FormControl } from '@angular/forms';
//import { ErrorStateMatcher } from '@angular/material/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApplicationsService } from '../../services/applicationsservice.service';
import { Application } from '../../models/application';
import { Environment } from '../../models/environment';
import { EnvironmentsService } from '../../services/environmentsservice.service';

@Component({
  selector: 'updateenvdashboard',
  templateUrl: './updateenvdashboard.component.html',
  styleUrls: ['./updateenvdashboard.component.css']
})
//frm: FormControl;
//this.frm = new FormControl('asdf');
export class updateenvdashboard implements OnInit {
  //errorMessage: any;
  ddlApplicationValue: string;
  applicationList: Application[];
  //appSelected: Number;
  ddlEnvironmentValue: string;
  environmentList: Environment[];
  //envSelected: Number;
  modifiedtext: string;

  txtAppVersion: string;
  txtDBVersion: string;

  constructor(public http: HttpClient, private _router: Router, private _avRoute: ActivatedRoute,
        private _applicationsService: ApplicationsService,
        private _environmentsService: EnvironmentsService) {   
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
      //this.latestChangeEvent = event.value;
      //console.error("whaaa");
      //console.info("help me!");
      //console.log(event);
      //console.log(value);
      //this.envSelected = val;
      this.getEnvironments(event.value);
        
  }
  changeSelect() { console.log("made it"); }

  getEnvironments(val: any) {
    //this.latestChangeEvent = "The value " + this.ddlApplicationValue + " was selected from the dropdown--";
    this._environmentsService.getEnvironmentsByAppId(val).subscribe(data => {
        this.environmentList = data;
    }
        , error => this.errorMessage = error)
  }


    save(f) {
        //if (!this.userForm.valid) {
        //    return;
        //}
    }

    cancel() {
        this._router.navigate(['/home']);
    }
}


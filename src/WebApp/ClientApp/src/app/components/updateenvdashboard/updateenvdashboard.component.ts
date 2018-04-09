import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { NgForm, FormsModule, Validators, FormControl } from '@angular/forms';
import { FormControl } from '@angular/forms';
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
    errorMessage: any;
    ddlApplicationValue: string;
    applicationList: Application[];
    //appSelected: Number;
    ddlEnvironmentValue: string;
    environmentList: Environment[];
    //envSelected: Number;
    modifiedtext: string;

  constructor(public http: HttpClient, private _router: Router, private _avRoute: ActivatedRoute,
        private _applicationsService: ApplicationsService,
        private _environmentsService: EnvironmentsService) {
        
    }

    ngOnInit() {
        //if (this.id > 0) {
        //    this.title = "Edit";
        //    this._userService.getUserById(this.id)
        //        .subscribe(resp => this.userForm.setValue(resp)
        //            , error => this.errorMessage = error);
        //}
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

      console.info("help me!");
      console.log(event);
      //console.log(value);
        //this.envSelected = val;
        //this.getEnvironments(val);
        
  }
  changeSelect() { console.log("made it") }

    getEnvironments(val: any) {
      this.modifiedtext = "The value " + this.ddlApplicationValue + " was selected from the dropdown--";
        //this._environmentsService.getEnvironmentsByAppId(val).subscribe(data => {
        //    this.environmentList = data;
        //}
        //    , error => this.errorMessage = error)
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


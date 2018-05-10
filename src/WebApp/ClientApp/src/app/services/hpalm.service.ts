import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpClientModule, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError, retry } from 'rxjs/operators';

import { RootObject } from '../models/hpalmdefects.class';
import { Entity } from '../models/hpalmdefects.class';
import { Field } from '../models/hpalmdefects.class';
import { Value } from '../models/hpalmdefects.class';
import { IHPALMDt1 } from '../models/hpalmdt1.datatable';
import { HPALMReleaseList } from '../models/hpalmreleaselist';
import { HPALMPivotData } from '../models/hpalmpivotdata';
import { HPALMSnapshotModel } from '../models/hpalmsnapshot.model';

@Injectable()
export class HPALMService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getHPALMDashboardView1(NewRelID: number = 0) {
    //console.log("myAppUrl: " + this.myAppUrl);
    //console.log('made it to: getHPALMDashboardView1.');

    let relid: number = 1078;
    if (NewRelID > 0) { relid = NewRelID }
    return this._http.get(this.myAppUrl + "api/HPALM/ReleaseBundle/" + relid)
      .map((data: any) => {

        let hpalmEntities: RootObject;
        let _entity: Entity[];
        let _hpalmDataTable: IHPALMDt1[] = [];

        hpalmEntities = data;
        //_entity = hpalmEntities.entities;
        let rows_inner = [];
        //_HPALMDt1
        for (let _entity of hpalmEntities.entities) {
          let _hpalmDataRow: IHPALMDt1 = {
            ReleaseBundle: '',
            FixingTeam: '',
            DefectID: '',
            ITSRIncidentNumber: '',
            Status: '',
            AssignedTo: '',
            Vertical: '',
            Severity: '',
            IncidentPriority: '',
            DefectCategory: '',
            PlannedReleaseDate: '',
            ITSRReleaseRequestComments: '',
            ArchitecturalReview: '',
            Developer: '',
            Project: '',
            Integrated: '',
            Description: '',
            Summary: '',
            IsNew: 'No',
          };
          //let _hpalmDataRow = {} as IHPALMDt1;
          //let _hpalmDataRow: IHPALMDt1;
          for (let _field of _entity.Fields) {
            let _FieldName = _field.Name;
            let _extractedValue: string = '';
            let _referenceValue: string = '';

            //console.log(_field.values.length);
            if (_field.values.length > 0) {
              for (let _valueArray of _field.values) {
                //console.log(_valueArray);
                if (_valueArray.value != null) {
                  _extractedValue = _valueArray.value;
                }
                if (_valueArray.ReferenceValue != null) {
                  _referenceValue = _valueArray.ReferenceValue;
                }
              }
            }
            //console.log("FieldName: " + _FieldName);
            //console.log("Value: " + _extractedValue);
            //console.log("Reference Value: " + _referenceValue);

            if (_FieldName == 'severity') { _hpalmDataRow.Severity = _extractedValue; }
            if (_FieldName == 'project') { _hpalmDataRow.Project = _extractedValue; }
            if (_FieldName == 'priority') { _hpalmDataRow.IncidentPriority = _extractedValue; }
            if (_FieldName == 'user-17') { _hpalmDataRow.AssignedTo = _extractedValue; }
            if (_FieldName == 'user-39') { _hpalmDataRow.Integrated = _extractedValue; }
            if (_FieldName == 'target-rel') { _hpalmDataRow.ReleaseBundle = _referenceValue; }
            if (_FieldName == 'user-29') { _hpalmDataRow.ITSRReleaseRequestComments = _extractedValue; }
            if (_FieldName == 'user-33') { _hpalmDataRow.ITSRIncidentNumber = _extractedValue; }
            if (_FieldName == 'user-12') { _hpalmDataRow.PlannedReleaseDate = _extractedValue; }
            if (_FieldName == 'id') { _hpalmDataRow.DefectID = _extractedValue; }
            if (_FieldName == 'user-21') { _hpalmDataRow.ArchitecturalReview = _extractedValue; }
            if (_FieldName == 'user-15') { _hpalmDataRow.FixingTeam = _extractedValue; }
            if (_FieldName == 'user-04') { _hpalmDataRow.Vertical = _extractedValue; }
            if (_FieldName == 'user-05') { _hpalmDataRow.DefectCategory = _extractedValue; }
            if (_FieldName == 'user-47') { _hpalmDataRow.Developer = _extractedValue; }
            if (_FieldName == 'status') { _hpalmDataRow.Status = _extractedValue; }
            if (_FieldName == 'description') { _hpalmDataRow.Description = _extractedValue; }
            if (_FieldName == 'name') { _hpalmDataRow.Summary = _extractedValue; }

          }

          //rows_inner.push(_hpalmDataRow, { detailRow: true, _hpalmDataRow })
          rows_inner.push(_hpalmDataRow)
        }

        // Now Query Snapshot from MSSQL and loop do a join and find exclusions, and mark those
        let objHpalmSnapshot: HPALMSnapshotModel[];
        this.getHPALMSnapshot().subscribe(res => {
          objHpalmSnapshot = res;
          //console.log(rows_inner);
          //console.log(objHpalmSnapshot);

          //console.log(rows_inner.length);
          for (var activeIndex = 0; activeIndex < rows_inner.length; activeIndex++) {
            let Active_DefectID: number = +rows_inner[activeIndex].DefectID;
            for (var snapshotIndex = 0; snapshotIndex < objHpalmSnapshot.length; snapshotIndex++) {
              let Snapshot_DefectID: number = +objHpalmSnapshot[snapshotIndex].defectID;
              if (Active_DefectID == Snapshot_DefectID) {
                rows_inner[activeIndex].IsNew = "No";
                break;
              } else {
                rows_inner[activeIndex].IsNew = "Yes";
              }
            }
          }
        });
        


        //console.log(rows_inner);
        return rows_inner;
      });
      //.pipe(catchError(this.handleError));

    //return this._http.get("http://localhost:50900/" + "api/HPALM/" + relid)
    //  .pipe(catchError(this.handleError));

    //return '';
  }

  getHPALMSnapshot() {
    return this._http.get(this.myAppUrl + "api/Snapshot/").pipe(catchError(this.handleError));
          //.map((response: Response) => objHpalmSnapshot = response.json())
          //.catch(this.handleError);
          //.pipe(catchError(this.handleError));
  }

  getHPALMReleaseList() {
    //console.log("myAppUrl: " + this.myAppUrl);
    //console.log('made it to: getHPALMDashboardView1.');
    let parentid: number = 110;
    return this._http.get(this.myAppUrl + "api/HPALM/ReleaseList/" + parentid)
      .map((data: any) => {

        let hpalmEntities: RootObject;
        let _entity: Entity[];
        let _hpalmDataTable: HPALMReleaseList[] = [];

        hpalmEntities = data;
        //_entity = hpalmEntities.entities;
        let rows_inner = [];
        //_HPALMDt1
        for (let _entity of hpalmEntities.entities) {
          let _hpalmDataRow: HPALMReleaseList = {
            name: '',
            id: 0,
            parentID: 0
          };
          for (let _field of _entity.Fields) {
            let _FieldName = _field.Name;
            let _extractedValue: string = '';
            let _referenceValue: string = '';
            if (_field.values.length > 0) {
              for (let _valueArray of _field.values) {
                if (_valueArray.value != null) {
                  _extractedValue = _valueArray.value;
                }
                if (_valueArray.ReferenceValue != null) {
                  _referenceValue = _valueArray.ReferenceValue;
                }
              }
            }
            //console.log("FieldName: " + _FieldName);
            //console.log("Value: " + _extractedValue);
            //console.log("Reference Value: " + _referenceValue);

            if (_FieldName == 'name') { _hpalmDataRow.name = _extractedValue; }
            if (_FieldName == 'id') { _hpalmDataRow.id = parseInt(_extractedValue, 10); }
            if (_FieldName == 'parent-id') { _hpalmDataRow.parentID = parseInt(_extractedValue, 10); }

          }
          rows_inner.push(_hpalmDataRow)
        }
        return rows_inner;
      });
  }

  getHPALMPivotData1(NewRelID: number = 0) {
    let relid: number = 1078;
    if (NewRelID > 0) { relid = NewRelID }
    return this._http.get(this.myAppUrl + "api/HPALM/PivotData1/" + relid)
      .map((data: any) => {

        let hpalmEntities: RootObject;
        let _entity: Entity[];
        let _hpalmDataTable: HPALMPivotData[] = [];

        hpalmEntities = data;
        //_entity = hpalmEntities.entities;
        let rows_inner = [];
        //_HPALMDt1
        for (let _entity of hpalmEntities.entities) {
          let _hpalmDataRow: HPALMPivotData = {
            projectTeam: '',
            status: '',
            defectID: 0,
            relID: 0
          };
          for (let _field of _entity.Fields) {
            let _FieldName = _field.Name;
            let _extractedValue: string = '';
            let _referenceValue: string = '';
            if (_field.values.length > 0) {
              for (let _valueArray of _field.values) {
                if (_valueArray.value != null) {
                  _extractedValue = _valueArray.value;
                }
                if (_valueArray.ReferenceValue != null) {
                  _referenceValue = _valueArray.ReferenceValue;
                }
              }
            }
            //console.log("FieldName: " + _FieldName);
            //console.log("Value: " + _extractedValue);
            //console.log("Reference Value: " + _referenceValue);

            if (_FieldName == 'user-15') { _hpalmDataRow.projectTeam = _extractedValue; }
            if (_FieldName == 'status') { _hpalmDataRow.status = _extractedValue; }
            if (_FieldName == 'id') { _hpalmDataRow.defectID = parseInt(_extractedValue, 10); }
            if (_FieldName == 'target-rel') { _hpalmDataRow.relID = parseInt(_extractedValue, 10); }

          }
          rows_inner.push(_hpalmDataRow)
        }
        return rows_inner;
      });
  }



  handleError(error: Response) {
    if ((<any>error).error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', (<any>error).error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${(<any>error).error}`);
    }

    return new ErrorObservable('There was an error from hpalm.dashboard.service.ts.  Please inspect the console logs.');
  }
}

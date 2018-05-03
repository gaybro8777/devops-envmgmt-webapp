import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { HPALMService } from '../../services/hpalm.service';
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { HPALMPivotData } from '../../models/hpalmpivotdata';


export interface Element {
  Project: string;
  Assigned: string;
  Duplicate: string;
  Total: string;
}
let someData: Array<Element> = [{'Project' : 'MIDDLEWARE', 'Assigned': '3', 'Duplicate': '-', 'Total' :  '10'},
  {'Project' : 'RIGHTANGLE', 'Assigned': '-', 'Duplicate': '-', 'Total' : '12'}];



@Component({
  selector: 'hpalm-release-bundle-pivot',
  templateUrl: './hpalm-release-bundle-pivot.component.html',
  styleUrls: ['./hpalm-release-bundle-pivot.component.scss']
})

export class HpalmReleaseBundlePivotComponent implements OnInit, AfterViewInit {

  ddlReleaseListValue: number = 1078;
  ReleaseText: string = '';

  public someColumns: string[];
  public someData: string[];

  _pivotData : HPALMPivotData[];
  //dataSource = new MatTableDataSource();
  displayedColumns = ["Project", "Assigned", "Duplicate", "Total"];

  //someData: any[] = [{'Project' : 'MIDDLEWARE', 'Assigned': 3, 'Duplicate': '-', 'Total' :  10},
  //{'Project' : 'RIGHTANGLE', 'Assigned': '-', 'Duplicate': '-', 'Total' : 12}];
  //dataSource = [ {"Project", "Assigned", "Duplicate", "In Progress", "Migrate to Production", "New", "RA Tulsa Support", "Ready for ,UAT", "UAT In Progress", "Unit Test", "Total"},{"MIDDLEWARE", 3, "-", 4, "-", 1, "-", 1, 1, "-", 10}];
  //someArrayData: any[] = [['MIDDLEWARE', '3', '-', '10'],['RIGHTANGLE', '-', '-','12']];
  //someArrayData = [{"Project" : "MIDDLEWARE", "Assigned": "3", "Duplicate": "-", "Total" :  "10"},
  //{"Project" : "RIGHTANGLE", "Assigned": "-", "Duplicate": "-", "Total" : "12"}];

  //dataSource = new MatTableDataSource(this.someArrayData);
  dataSource = someData;

  constructor(private _HPALMService: HPALMService, private route: ActivatedRoute) {
    if (this.route.snapshot.params["relid"]) {
      this.ddlReleaseListValue = this.route.snapshot.params["relid"];
    }
  }

  ngOnInit() {
    this.CreatePivotData();
  }
  ngAfterViewInit() {
    //this.GetDataSource();
    // console.log("ngAfterViewInit");
    //console.log(this.dataSource);
    //console.log(this.displayedColumns);
  }

  CreatePivotData()
  {
    this._HPALMService.getHPALMPivotData1(this.ddlReleaseListValue).subscribe(data => {
      this._pivotData = data;
      //console.log(this.dataSource.data);
      //console.log(this._pivotData);

      let _NewPivotData = this.getPivotArray(this._pivotData, 1, 3, 0);
      //console.log(_NewPivotData);
      this.someData = _NewPivotData;
      //console.log(this.someData);
      
      //this.displayedColumns = _NewPivotData[0];
      this.someColumns = _NewPivotData[0];

      //console.log(_NewPivotData[0]);
      // console.log("Lets see what the datasource data looks like:");
      //console.log(this.dataSource.data);

    });
  }

  getPivotArray(dataArray, rowIndex, colIndex, dataIndex) {
    //Code from https://techbrij.com
    var result = {}, ret = [];
    var newCols = [];
    for (var i = 0; i < dataArray.length; i++) {
      if (!result[dataArray[i].projectTeam]) {
        result[dataArray[i].projectTeam] = {};
      }

      if (!result[dataArray[i].projectTeam][dataArray[i].status]) {
        result[dataArray[i].projectTeam][dataArray[i].status] = 1;
      }
      else {
        result[dataArray[i].projectTeam][dataArray[i].status] = result[dataArray[i].projectTeam][dataArray[i].status] + 1;
      }
      
        //result[dataArray[i].projectTeam][dataArray[i].status] = dataArray[i].defectID;
        //console.log(dataArray[i]);
        //To get column names
        if (newCols.indexOf(dataArray[i].status) == -1) {
            newCols.push(dataArray[i].status);
        }
    }
    
    console.log(result);

    newCols.sort();

    // Add Total Column
    newCols.push("Total");

    var item = [];

    //Add Header Row
    item.push('Project');
    item.push.apply(item, newCols);
    ret.push(item);

    //console.log(newCols);
    // for (var key in result) {
    //   console.log(key);
    // }

    //Add content 
    for (var key in result) {
        item = [];
        item.push(key);
        //console.log(item);
        var runningTotalColumn = 0;
        for (var i = 0; i < newCols.length; i++) {

          // Keep running total for rows
          if(result[key][newCols[i]]) { 
            runningTotalColumn += result[key][newCols[i]];
          }

          // If on last TOTAL column, then add running total for rows
          if ( i == (newCols.length - 1)) {
            item.push(runningTotalColumn);
          } else {
            item.push(result[key][newCols[i]] || "-");
          }
        }
        //item.push(result[key][newCols[ newCols.length - 1 ]]);
        //console.log(runningTotalColumn);
        ret.push(item);
    }
    return ret;
  }
}

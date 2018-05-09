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
import { IHPALMPivotData } from '../../models/hpalmpivotdata';

export interface Element {
  Project: string;
  Assigned: string;
  Duplicate: string;
  Total: string;
}

@Component({
  selector: 'hpalm-release-bundle-pivot',
  templateUrl: './hpalm-release-bundle-pivot.component.html',
  styleUrls: ['./hpalm-release-bundle-pivot.component.scss']
})

export class HpalmReleaseBundlePivotComponent implements OnInit, AfterViewInit {

  ddlReleaseListValue: number = 1078;
  ReleaseText: string = '';

  _pivotData : IHPALMPivotData[];
  dataSource = new MatTableDataSource();

  displayedColumns: string[] = [];
  columns: object[] = [];
  tableData: string[] = [];

  resourcesLoaded: boolean = false;
  isDataEmpty: boolean = false;

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
  }

  CreatePivotData()
  {
    this.isDataEmpty = false;
    this.resourcesLoaded = false;
    this._HPALMService.getHPALMPivotData1(this.ddlReleaseListValue).subscribe(data => {
      this._pivotData = data;

      let _NewPivotData = this.getPivotArray(this._pivotData, 1, 3, 0);
      //let _FinalPivotData = this.convertPivotArrayToArryofObjects(_NewPivotData);

      this.displayedColumns = _NewPivotData[0];
      this.columns = this.generateColumns(_NewPivotData[0]);

      _NewPivotData.shift();
      _NewPivotData = _NewPivotData.sort(this.Comparator);

      let FootTotalRow = this.CreateSummationRow(_NewPivotData);
      _NewPivotData.push(FootTotalRow);
      this.dataSource.data = _NewPivotData;

      if (this.dataSource.data.length == 0) { this.isDataEmpty = true; }
      this.resourcesLoaded = true;
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
      
        //To get column names
        if (newCols.indexOf(dataArray[i].status) == -1) {
            newCols.push(dataArray[i].status);
        }
    }

    newCols.sort();

    // Add Total Column
    newCols.push("Total");

    var item = [];

    //Add Header Row
    item.push('Project');
    item.push.apply(item, newCols);
    ret.push(item);

    //Add content 
    for (var key in result) {
        item = [];
        item.push(key);
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
        ret.push(item);
    }
    return ret;
  }

  convertPivotArrayToArryofObjects(pivotArray) {
    let  finalArryOfObjects = [];
    let columnHeaderArray = pivotArray[0];
    
    for (var rowIdx = 1; rowIdx < pivotArray.length; rowIdx++) {
      let _rowOfObjects = {}
      for (var colIdx = 0; colIdx < columnHeaderArray.length; colIdx++) {
          
          if(Number.isInteger(pivotArray[rowIdx][colIdx])) {
            _rowOfObjects["\"" + columnHeaderArray[colIdx] + "\""] = pivotArray[rowIdx][colIdx].toString() ;
          } else {
            _rowOfObjects["\"" + columnHeaderArray[colIdx] + "\""] = pivotArray[rowIdx][colIdx];
          }
      }
      
      finalArryOfObjects.push(_rowOfObjects);
    }
    return finalArryOfObjects;
  }

  generateColumns(tableColumns: string[])                                                           // Create columns, this is an array of objects. The object the holds the headingName, Label and Cell 
  {

    var innerIndex: number = 1;
    var columnObj: object;
    var columns: object[] = [];

    for (var i = 0; i < tableColumns.length; i++) {

      columnObj = new function () {
        this.columnDef = tableColumns[i].toString();
        this.header = tableColumns[i].toString();
        this.cell = [];
      }
      columns.push(columnObj)
    }
    return columns;
  }

  Comparator(a, b) {
    if (a[0] < b[0]) return -1;
    if (a[0] > b[0]) return 1;
    return 0;
  }

  CreateSummationRow(dataArray) {
    let sumRow = [];
    sumRow.push("Total");
    if (dataArray.length > 0) {
      let colSize = dataArray[0].length;
      for (var colIdx = 1; colIdx < colSize; colIdx++) {
        let rowObj = [];
        let ColumnTotal = 0;
        for (var rowIdx = 0; rowIdx < dataArray.length; rowIdx++) {
          rowObj = dataArray[rowIdx];
          if (Number.isInteger(rowObj[colIdx])) {
            ColumnTotal = ColumnTotal + rowObj[colIdx]
          }
        }
        sumRow.push(ColumnTotal);
      }   
    }
    return sumRow;
  }
}

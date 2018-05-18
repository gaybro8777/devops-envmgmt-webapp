import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatSort } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

import { HPALMService } from '../../services/hpalm.service';
import { IHPALMDt1 } from '../../models/hpalmdt1.datatable';

import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { HPALMReleaseList } from '../../models/hpalmreleaselist';
import { HPALMSnapshotListModel } from '../../models/hpalmsnapshot.model';
import * as moment from 'moment';

@Component({
  selector: 'hpalm-dashboard-component',
  templateUrl: './hpalm-dashboard.component.html',
  styleUrls: ['./hpalm-dashboard.component.css'],
  animations: [
    trigger('detailExpand', [
      state('void', style({ height: '0px', minHeight: '0', visibility: 'hidden' })),
      state('*', style({ height: '*', visibility: 'visible' })),
      transition('void <=> *', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ])
  ],
})

//public tblDataSource: MatTableDataSource;

//  implements OnInit
export class HPALMDashboardComponent implements OnInit, AfterViewInit  {

  expandCollapseIcon: 'keyboard_arrow_down';
  releaseList: HPALMReleaseList[];
  snapshotList: HPALMSnapshotListModel[];
  ddlReleaseListValue: number = 1078;
  ddlSnapshotListValue: number = 0;
  ReleaseText: string = '';

  resourcesLoaded: boolean = false;
  isDataEmpty: boolean = false;

  constructor(private _HPALMService: HPALMService, private route: ActivatedRoute) {
    if (this.route.snapshot.params["relid"]) {
      this.ddlReleaseListValue = this.route.snapshot.params["relid"];
    }
  }

  displayedColumns = ['DefectID', 'Summary', 'ReleaseBundle', 'FixingTeam','Status',
    'AssignedTo', 'Vertical', 'DefectCategory', 'ArchitecturalReview', 'Developer', 'Project', 'Integrated'];
  dataSource = new MatTableDataSource<IHPALMDt1>();
  @ViewChild(MatSort) sort: MatSort;

  //isExpansionDetailRow = (i: number, row: Object) => row.hasOwnProperty('detailRow');
  isExpansionDetailRow = (index, row) => row.hasOwnProperty('detailRow');
  expandedElement: any;

  /**
   * Set the sort after the view init since this component will
   * be able to query its view for the initialized sort.
   */
  ngAfterViewInit() {
    this.GetDataSource();
  }

  GetDataSource() {
    this.dataSource.data = [];
    this.isDataEmpty = false;
    this.resourcesLoaded = false;
    this._HPALMService.getHPALMDashboardView1(this.ddlReleaseListValue, this.ddlSnapshotListValue).subscribe(data => {
      this.dataSource.data = data;
      if (this.dataSource.data.length == 0) { this.isDataEmpty = true; }
      this.resourcesLoaded = true;
    });
    
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
    this.getReleaseList();
    this.getSnapshotList();
  }

  getReleaseList() {
    this._HPALMService.getHPALMReleaseList().subscribe(data => {
      this.releaseList = data;
      //this.ddlReleaseListValue = this.ddlReleaseListValue;
      var filteredElements = data.filter(x => x.id == this.ddlReleaseListValue);
      if (filteredElements.length > 0) { this.ReleaseText = filteredElements[0].name; }
    });
  }

  getSnapshotList() {
    this._HPALMService.getHPALMSnapshotList().subscribe(data => {
      this.snapshotList = data;
      let defaultValue: number = 0;
      if(this.snapshotList.length > 0) {
        defaultValue = this.snapshotList[this.snapshotList.length - 1].snapshotID;
      }
      this.ddlSnapshotListValue = defaultValue;
    });
  }

  onReleaseListSelected(event) {
    // this.ddlReleaseListValue = parseInt(event.value);
    this.ReleaseText = event.source.triggerValue;
    this.GetDataSource()
  }

  onSnapshotListChange(event) {
    // this.ddlSnapshotListValue = parseInt(event.value);
    this.GetDataSource()
  }
}

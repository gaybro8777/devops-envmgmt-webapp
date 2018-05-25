import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatSort } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

import { HPALMService } from '../../services/hpalm.service';
import { IHPALMDt1 } from '../../models/hpalmdt1.datatable';
import { ExcelService } from '../../services/excel.service';

import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { HPALMReleaseList } from '../../models/hpalmreleaselist';
import { HPALMSnapshotListModel } from '../../models/hpalmsnapshot.model';
import * as moment from 'moment';
import { Angular5TimePickerModule } from 'angular5-time-picker';

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
  ddlReleaseListValue: number = 1079;
  ddlSnapshotListValue: number = 0;
  ReleaseText: string = '';

  resourcesLoaded: boolean = false;
  isDataEmpty: boolean = false;

  constructor(private _HPALMService: HPALMService, private route: ActivatedRoute, private _ExcelService: ExcelService) {
    if (this.route.snapshot.params["relid"]) {
      this.ddlReleaseListValue = this.route.snapshot.params["relid"];
    }
  }

  displayedColumns = ['DefectID', 'Project', 'Summary', 'ReleaseBundle', 'FixingTeam','Status',
    'AssignedTo', 'Vertical', 'DefectCategory', 'ArchitecturalReview', 'Developer', 'Integrated'];
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
    this._HPALMService.getHPALMDashboardView1(this.ddlReleaseListValue, 0).subscribe(data => {
      this.dataSource.data = data;
      if (this.dataSource.data.length == 0) { this.isDataEmpty = true; }
      this.resourcesLoaded = true;
    });
    
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
    this.getReleaseList();
  }

  getReleaseList() {
    this._HPALMService.getHPALMReleaseList().subscribe(data => {
      this.releaseList = data;
      //this.ddlReleaseListValue = this.ddlReleaseListValue;
      var filteredElements = data.filter(x => x.id == this.ddlReleaseListValue);
      if (filteredElements.length > 0) { this.ReleaseText = filteredElements[0].name; }
    });
  }

  onReleaseListSelected(event) {
    // this.ddlReleaseListValue = parseInt(event.value);
    this.ReleaseText = event.source.triggerValue;
    this.GetDataSource()
  }

  


}

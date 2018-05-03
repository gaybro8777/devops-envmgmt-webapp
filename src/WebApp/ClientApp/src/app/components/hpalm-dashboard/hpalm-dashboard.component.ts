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
  ddlReleaseListValue: number = 1078;
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
  //dataSource = new ExampleDataSource(this._HPALMService);
  //exampleDatabase: ExampleDataSource | null;
  dataSource = new MatTableDataSource<IHPALMDt1>();
  @ViewChild(MatSort) sort: MatSort;
  //selection = new SelectionModel<IHPALMDt1>(true, []);

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
    this._HPALMService.getHPALMDashboardView1(this.ddlReleaseListValue).subscribe(data => {
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
    //console.log(event);
    //console.log(event.source.selected.id);
    //console.log(event.source._keyManager._items._results);
    // .value = 1077
    // .source._keyManager._items._results[4].id = "mat-option-4"
    // .source._keyManager._items._results[4].viewValue = "0420 Rel"
    // .source.triggerValue = "0420 Rel"
    this.ddlReleaseListValue = parseInt(event.value);
    this.ReleaseText = event.source.triggerValue;
    this.GetDataSource()
  }

  /** Whether the number of selected elements matches the total number of rows. */
  //isAllSelected() {
  //  const numSelected = this.selection.selected.length;
  //  const numRows = this.dataSource.data.length;
  //  return numSelected === numRows;
  //}

  ///** Selects all rows if they are not all selected; otherwise clear selection. */
  //masterToggle() {
  //  this.isAllSelected() ?
  //    this.selection.clear() :
  //    this.dataSource.data.forEach(row => this.selection.select(row));
  //}
}



//  extends DataSource<any>
export class ExampleDataSource {

  constructor(private _HPALMService: HPALMService) {
    //super();
  }

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  //: IHPALMDt1[]
  connect(): Observable<IHPALMDt1[]> {
    console.log("got called!");
    let dataItems: Observable<IHPALMDt1[]>;
    //this._HPALMService.getHPALMDashboardView1().subscribe(data => {
    //  //dataItems = data;
    //  //console.log(data);
    //  this.tblDataSource = data;
    //  return data;
    //});
    ////console.log(dataItems);
    ////return dataItems;

    //dataItems = this._HPALMService.getHPALMDashboardView1().map((data) => { return data; });
    dataItems = this._HPALMService.getHPALMDashboardView1();
    return dataItems;
  }

  connectGOOD(): Observable<IHPALMDt1[]> {
    return this._HPALMService.getHPALMDashboardView1().map((data) => { return data });
  }

  disconnect() { }

}


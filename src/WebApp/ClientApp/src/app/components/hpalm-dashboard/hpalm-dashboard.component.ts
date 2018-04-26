import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatSort } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

import { HPALMService } from '../../services/hpalm.dashboard1.service';
import { IHPALMDt1 } from '../../models/hpalmdt1.datatable';

import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { animate, state, style, transition, trigger } from '@angular/animations';


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
export class TableComponent implements AfterViewInit  {

  expandCollapseIcon: 'keyboard_arrow_down';

  constructor(private _HPALMService: HPALMService) {
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
    this._HPALMService.getHPALMDashboardView1().subscribe(data => {
      this.dataSource.data = data;
      //console.log(this.dataSource.data);
    });
    this.dataSource.sort = this.sort;
  }

  //onRowExpandClick(event) {
  //  console.log(event);
  //  //keyboard_arrow_down
  //}

  //ngOnInit() {
  //  //let ds1 = new ExampleDataSource(this._HPALMService);
  //  ////.subscribe(data => this.dataSource.data = data);
  //  ////this.dataSource.data = ds1.connect;
  //  //let data = ds1.connect();
  //  //console.log(data);


  //  this._HPALMService.getHPALMDashboardView1().subscribe(data => {
  //    this.dataSource.data = data;
  //    //console.log(this.dataSource.data);
  //  });
  //  //this.dataSource.paginator = this.paginator;
  //  this.dataSource.sort = this.sort;
  //}

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


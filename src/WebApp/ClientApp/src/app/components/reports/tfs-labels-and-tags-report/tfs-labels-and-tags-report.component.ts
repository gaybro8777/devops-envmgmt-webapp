import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatSort } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

import { TfsService } from '../../../services/tfs.service';
import { TfsLabels } from '../../../models/tfs.model';
import * as moment from 'moment';

@Component({
    moduleId: module.id,
    selector: 'tfs-labels-and-tags-report',
    templateUrl: 'tfs-labels-and-tags-report.component.html',
    styleUrls: ['tfs-labels-and-tags-report.component.scss']
})
export class TfsLabelsAndTagsReportComponent implements OnInit, AfterViewInit {
  resourcesLoaded: boolean = false;
  isDataEmpty: boolean = false;

  constructor(private _TfsService: TfsService, private route: ActivatedRoute) {
  }

  displayedColumns = ['labelName', 'comment', 'changeset', 'projectName','path','lastModifedString', 'user'];
  dataSource = new MatTableDataSource<TfsLabels>();
  @ViewChild(MatSort) sort: MatSort;

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
    this._TfsService.getTFSLabels().subscribe(data => {
      let tfsDataSet: TfsLabels[] = data;
      //console.log(tfsDataSet);
      for (var i = 0; i < tfsDataSet.length; i++) {
        
        //console.log(tfsDataSet[i].lastModified);
        let _modifiedDateTime = moment(tfsDataSet[i].lastModified);
        //console.log(_modifiedDateTime.format('l LT'));
        //let newdt = moment();
        tfsDataSet[i].lastModifedString = _modifiedDateTime.format('l LT');
      }

      this.dataSource.data = tfsDataSet;
      //console.log(this.dataSource.data);
      if (this.dataSource.data.length == 0) { this.isDataEmpty = true; }
      this.resourcesLoaded = true;
    });
    this.dataSource.sort = this.sort;

    this.dataSource.sortingDataAccessor = (item, property) => {
      switch (property) {
        case 'lastModifedString': return new Date(item.lastModified);
        default: return item[property];
      }
    };
  }

  ngOnInit() {

  }
}

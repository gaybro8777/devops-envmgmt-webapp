import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatSort } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

import { TfsService } from '../../../services/tfs.service';
import { TfsLabels } from '../../../models/tfs.model';

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

  displayedColumns = ['labelName', 'comment', 'changeset', 'projectName','path','lastModified', 'user'];
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
      this.dataSource.data = data;
      if (this.dataSource.data.length == 0) { this.isDataEmpty = true; }
      this.resourcesLoaded = true;
    });
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
  }
}

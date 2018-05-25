import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material';

import { HPALMService } from './services/hpalm.service';
import { TfsService } from './services/tfs.service';
import { ExcelService } from './services/excel.service';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StateService } from './state-service';

import { HomeComponent } from './components/home/home.component';
import { HPALMDashboardComponent } from './components/hpalm-dashboard/hpalm-dashboard.component';
import { CdkDetailRowDirective } from './components/hpalm-dashboard/cdk-detail-row.directive';
import { HpalmReleaseBundlePivotComponent } from './components/hpalm-release-bundle-pivot/hpalm-release-bundle-pivot.component';
import { HpalmReleaseBundlePivotByProjectComponent } from './components/hpalm-release-bundle-pivot-by-project/hpalm-release-bundle-pivot-by-project.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HPALMDashboardComponent,
    CdkDetailRowDirective,
    HpalmReleaseBundlePivotComponent,
    HpalmReleaseBundlePivotByProjectComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule, ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [ ErrorStateMatcher, ShowOnDirtyErrorStateMatcher,
    StateService, HPALMService, TfsService, ExcelService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

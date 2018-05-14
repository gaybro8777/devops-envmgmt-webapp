import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material';

import { AuthenticationService } from './services/authentication.service';
import { ApplicationsService } from './services/applications.service';
import { EnvironmentsService } from './services/environments.service';
import { EnvStatusService } from './services/envstatus.service';
import { ProjectTeamService } from './services/projectteam.service';
import { UsersService } from './services/users.service';
import { HPALMService } from './services/hpalm.service';
import { TfsService } from './services/tfs.service';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StateService } from './state-service';

import { HomeComponent } from './components/home/home.component';
import { adminhomepage } from './components/admin/adminhomepage/adminhomepage.component';
import { RetrieveUsersComponent } from './components/admin/retrieveusers/retrieveusers.component';
import { adduser } from './components/admin/addusers/addusers.component';
import { updateenvdashboard } from './components/updateenvdashboard/updateenvdashboard.component';
import { EnvRequestForm } from './components/envrequestform/envrequestform.component';
import { HPALMDashboardComponent } from './components/hpalm-dashboard/hpalm-dashboard.component';
import { CdkDetailRowDirective } from './components/hpalm-dashboard/cdk-detail-row.directive';
import { HpalmReleaseBundlePivotComponent } from './components/hpalm-release-bundle-pivot/hpalm-release-bundle-pivot.component';
import { TfsLabelsAndTagsReportComponent } from './components/reports/tfs-labels-and-tags-report/tfs-labels-and-tags-report.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    adminhomepage,
    RetrieveUsersComponent, adduser, updateenvdashboard, EnvRequestForm,
    HPALMDashboardComponent,
    CdkDetailRowDirective,
    HpalmReleaseBundlePivotComponent,
    TfsLabelsAndTagsReportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule, ReactiveFormsModule,
    AppRoutingModule,
    // RouterModule.forRoot([
    //   { path: '', component: HomeComponent, pathMatch: 'full' },
    //   { path: 'home', component: HomeComponent },
    //   { path: 'counter', component: CounterComponent },
    //   { path: 'fetch-data', component: FetchDataComponent },
    //   { path: 'admin', component: adminhomepage },
    //   { path: 'admin/retrieve-user', component: RetrieveUsersComponent },
    //   { path: 'admin/adduser', component: adduser },
    //   { path: 'admin/adduser/:id', component: adduser },
    //   { path: 'updateenvdashboard', component: updateenvdashboard },
    //   { path: '**', redirectTo: 'home' }
    // ])
    // { path: '', component: HomeComponent, pathMatch: 'full' },
    // { path: 'admin/adduser', component: adduser },
    // { path: 'admin/edituser/:id', component: adduser }
  ],
  providers: [ ErrorStateMatcher, ShowOnDirtyErrorStateMatcher, AuthenticationService, 
    ApplicationsService, EnvironmentsService, EnvStatusService, ProjectTeamService, UsersService,
    StateService, HPALMService, TfsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material';

import { ApplicationsService } from './services/applications.service';
import { EnvironmentsService } from './services/environments.service';
import { EnvStatusService } from './services/envstatus.service';
import { UsersService } from './services/users.service';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { StateService } from './state-service';

import { HomeComponent } from './components/home/home.component';
import { adminhomepage } from './components/admin/adminhomepage/adminhomepage.component';
import { RetrieveUsersComponent } from './components/admin/retrieveusers/retrieveusers.component';
import { adduser } from './components/admin/addusers/addusers.component';
import { updateenvdashboard } from './components/updateenvdashboard/updateenvdashboard.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    adminhomepage,
    RetrieveUsersComponent, adduser, updateenvdashboard
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
  providers: [ ErrorStateMatcher, ShowOnDirtyErrorStateMatcher,
    ApplicationsService, EnvironmentsService, EnvStatusService, UsersService,
    StateService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

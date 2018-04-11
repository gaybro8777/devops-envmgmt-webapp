import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { SidenavComponent } from './sidenav/sidenav.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { adminhomepage } from './components/admin/adminhomepage/adminhomepage.component';
import { RetrieveUsersComponent } from './components/admin/retrieveusers/retrieveusers.component';
import { adduser } from './components/admin/addusers/addusers.component';
import { updateenvdashboard } from './components/updateenvdashboard/updateenvdashboard.component';

import { APP_BASE_HREF } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
    SidenavComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    adminhomepage,
    RetrieveUsersComponent, adduser, updateenvdashboard
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule, ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'admin', component: adminhomepage },
      { path: 'admin/retrieve-user', component: RetrieveUsersComponent },
      { path: 'admin/adduser', component: adduser },
      { path: 'admin/adduser/:id', component: adduser },
      { path: 'updateenvdashboard', component: updateenvdashboard },
      { path: '**', redirectTo: 'home' }
    ])
    // { path: '', component: HomeComponent, pathMatch: 'full' },
    // { path: 'admin/adduser', component: adduser },
    // { path: 'admin/edituser/:id', component: adduser }
  ],
  providers: [ ErrorStateMatcher, ShowOnDirtyErrorStateMatcher,
    ApplicationsService, EnvironmentsService, EnvStatusService, UsersService,
    { provide: APP_BASE_HREF, useValue: '/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

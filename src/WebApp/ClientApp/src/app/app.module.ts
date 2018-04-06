import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material';

import { ApplicationsService } from './services/applicationsservice.service';
import { EnvironmentsService } from './services/environmentsservice.service';
import { UsersService } from './services/usersservice.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { adminhomepage } from './components/admin/adminhomepage/adminhomepage.component';
import { RetrieveUsersComponent } from './components/admin/retrieveusers/retrieveusers.component';
import { adduser } from './components/admin/addusers/addusers.component';

import { APP_BASE_HREF } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    adminhomepage,
    RetrieveUsersComponent, adduser
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
      { path: '**', redirectTo: 'home' }
    ])
    // { path: '', component: HomeComponent, pathMatch: 'full' },
    // { path: 'admin/adduser', component: adduser },
    // { path: 'admin/edituser/:id', component: adduser }
  ],
  providers: [ ErrorStateMatcher, ShowOnDirtyErrorStateMatcher,
    ApplicationsService, EnvironmentsService, UsersService,
    { provide: APP_BASE_HREF, useValue: '/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

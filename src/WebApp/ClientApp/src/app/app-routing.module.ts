import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { adminhomepage } from './components/admin/adminhomepage/adminhomepage.component';
import { RetrieveUsersComponent } from './components/admin/retrieveusers/retrieveusers.component';
import { adduser } from './components/admin/addusers/addusers.component';
import { updateenvdashboard } from './components/updateenvdashboard/updateenvdashboard.component';
import { EnvRequestForm } from './components/envrequestform/envrequestform.component';

import { TableComponent } from './components/hpalm-dashboard/hpalm-dashboard.component';
import { CdkDetailRowDirective } from './components/hpalm-dashboard/cdk-detail-row.directive';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'admin', component: adminhomepage },
  { path: 'admin/retrieve-user', component: RetrieveUsersComponent },
  { path: 'admin/adduser', component: adduser },
  { path: 'admin/adduser/:id', component: adduser },
  { path: 'envrequestform', component: EnvRequestForm},
  { path: 'updateenvdashboard', component: updateenvdashboard },
  { path: 'hpalmdashboard', component: TableComponent },
  { path: '**', redirectTo: 'home' }
];


@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot( routes, { useHash: true } ),
  ],
  providers: [  ],
  declarations: [ ],
  exports: [
    RouterModule
  ],
})

export class AppRoutingModule {}

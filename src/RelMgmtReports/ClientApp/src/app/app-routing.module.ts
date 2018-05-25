import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { HpalmReleaseBundlePivotComponent } from './components/hpalm-release-bundle-pivot/hpalm-release-bundle-pivot.component';
import { HpalmReleaseBundlePivotByProjectComponent } from './components/hpalm-release-bundle-pivot-by-project/hpalm-release-bundle-pivot-by-project.component';
import { HPALMDashboardComponent } from './components/hpalm-dashboard/hpalm-dashboard.component';
import { CdkDetailRowDirective } from './components/hpalm-dashboard/cdk-detail-row.directive';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'hpalmdashboard', component: HPALMDashboardComponent },
  { path: 'hpalmdashboard/:relid', component: HPALMDashboardComponent },
  { path: 'HpalmReleaseBundlePivotComponent', component: HpalmReleaseBundlePivotComponent },
  { path: 'HpalmReleaseBundlePivotComponent/:relid', component: HpalmReleaseBundlePivotComponent },
  { path: 'HpalmReleaseBundlePivotByProjectComponent', component: HpalmReleaseBundlePivotByProjectComponent },
  { path: 'HpalmReleaseBundlePivotByProjectComponent/:relid', component: HpalmReleaseBundlePivotByProjectComponent }
];
//,
//{ path: '**', redirectTo: 'home' }

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot( routes, { useHash: false } ),
  ],
  providers: [  ],
  declarations: [
   ],
  exports: [
    RouterModule
  ],
})

export class AppRoutingModule {}

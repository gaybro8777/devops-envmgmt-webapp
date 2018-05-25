import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

// Only Components that need to be routed should be delcared here.
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent }
];

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot( routes, { useHash: false } ),
  ],
  providers: [  ],
  declarations: [  ],
  exports: [
    RouterModule
  ],
})

export class AppRoutingModule {}

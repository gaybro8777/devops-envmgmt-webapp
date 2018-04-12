import { AfterContentInit, Component, ContentChildren, EventEmitter, Input, Output, QueryList } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd, RouterStateSnapshot } from '@angular/router';

@Component({
  selector: 'side-nav-group',
  template:
    `<div class="side-nav-group">
        <div *ngIf="title" class="side-nav-group-title">
          <span style="padding: 0 16px;">{{ title }}</span>
        </div>
        <ng-content></ng-content>
    </div>`,
  styles: [`
    .side-nav-group{
      border-width:1px 0px 1px 0px;border-style:solid;border-color:#e0e0e0
    }
    .side-nav-group-title{
      background:rgba(0,0,0,.32);color:hsla(0,0%,100%,.87);width:100%
    }
  `]
})
export class SideNavGroupComponent {
  @Input('title') title: string;

}

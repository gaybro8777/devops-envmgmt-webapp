import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
  MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
  MatNativeDateModule, MatRadioModule, MatSnackBarModule, 
  MatOptionModule, MatSlideToggleModule, ErrorStateMatcher,
  ShowOnDirtyErrorStateMatcher, MatTableModule, MatSortModule,
  MatButtonToggleModule
} from '@angular/material';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SideNavMenuModule } from 'mat-sidenav-menu';
import { Angular5TimePickerModule } from 'angular5-time-picker';

import { A11yModule } from '@angular/cdk/a11y';
import { BidiModule } from '@angular/cdk/bidi';
import { ObserversModule } from '@angular/cdk/observers';
import { OverlayModule } from '@angular/cdk/overlay';
import { PlatformModule } from '@angular/cdk/platform';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollDispatchModule } from '@angular/cdk/scrolling';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';


@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatRadioModule, MatSidenavModule,
    MatSelectModule, MatOptionModule, MatSlideToggleModule, SideNavMenuModule,
    Angular5TimePickerModule, MatSnackBarModule,
    MatTableModule, MatSortModule, MatButtonToggleModule,
    A11yModule,
    BidiModule,
    ObserversModule,
    OverlayModule,
    PlatformModule,
    PortalModule,
    ScrollDispatchModule,
    CdkStepperModule,
    CdkTableModule
  ],
  exports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatRadioModule, MatSidenavModule,
    MatSelectModule, MatOptionModule, MatSlideToggleModule, SideNavMenuModule,
    Angular5TimePickerModule, MatSnackBarModule,
    MatTableModule, MatSortModule, MatButtonToggleModule,
    A11yModule,
    BidiModule,
    ObserversModule,
    OverlayModule,
    PlatformModule,
    PortalModule,
    ScrollDispatchModule,
    CdkStepperModule,
    CdkTableModule
    ]
})

export class MaterialModule { }

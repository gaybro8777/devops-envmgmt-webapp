import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
  MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
  MatNativeDateModule, MatRadioModule, MatSnackBarModule, 
  MatOptionModule, MatSlideToggleModule, ErrorStateMatcher,
  ShowOnDirtyErrorStateMatcher
} from '@angular/material';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SideNavMenuModule } from 'mat-sidenav-menu';
import { Angular5TimePickerModule } from 'angular5-time-picker';


@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatRadioModule, MatSidenavModule,
    MatSelectModule, MatOptionModule, MatSlideToggleModule, SideNavMenuModule,
    Angular5TimePickerModule, MatSnackBarModule],
  exports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatRadioModule, MatSidenavModule,
    MatSelectModule, MatOptionModule, MatSlideToggleModule, SideNavMenuModule,
    Angular5TimePickerModule, MatSnackBarModule]
})

export class MaterialModule { }

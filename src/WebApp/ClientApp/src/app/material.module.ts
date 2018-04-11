import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
  MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
  MatNativeDateModule, MatRadioModule, MatSidenavModule,
  MatOptionModule, MatSlideToggleModule, ErrorStateMatcher,
  ShowOnDirtyErrorStateMatcher
} from '@angular/material';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';


@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatRadioModule, MatSidenavModule,
    MatSelectModule, MatOptionModule, MatSlideToggleModule],
  exports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatRadioModule, MatSidenavModule,
    MatSelectModule, MatOptionModule, MatSlideToggleModule]
})

export class MaterialModule { }

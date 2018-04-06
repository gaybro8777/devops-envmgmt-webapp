import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
  MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
  MatNativeDateModule, MatRadioModule,
  MatSelectModule, MatOptionModule, MatSlideToggleModule, ErrorStateMatcher,
  ShowOnDirtyErrorStateMatcher
} from '@angular/material';
import { MatDatepickerModule } from '@angular/material/datepicker';
// MatDatepicker

@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatRadioModule,
    MatSelectModule, MatOptionModule, MatSlideToggleModule],
  exports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatRadioModule,
    MatSelectModule, MatOptionModule, MatSlideToggleModule]
})

export class MaterialModule { }

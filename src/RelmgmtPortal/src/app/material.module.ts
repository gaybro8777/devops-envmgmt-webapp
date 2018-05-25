import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
  MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
  MatNativeDateModule, MatRadioModule, MatSnackBarModule, 
  MatOptionModule, MatSlideToggleModule, MatTableModule,
  MatButtonToggleModule
} from '@angular/material';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatGridListModule } from '@angular/material/grid-list';


@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatNativeDateModule, MatRadioModule, 
    MatSelectModule, MatOptionModule, MatSlideToggleModule, 
    MatSnackBarModule, MatTableModule, MatButtonToggleModule, MatGridListModule
  ],
  exports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatToolbarModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule,
    MatNativeDateModule, MatRadioModule, 
    MatSelectModule, MatOptionModule, MatSlideToggleModule, 
    MatSnackBarModule, MatTableModule, MatButtonToggleModule, MatGridListModule
    ]
})

export class MaterialModule { }

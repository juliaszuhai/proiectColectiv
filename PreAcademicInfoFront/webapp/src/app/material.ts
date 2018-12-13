import {
  MatButtonModule,
  MatCheckboxModule,
  MatDividerModule, MatGridListModule,
  MatOptionModule,
  MatSelectModule, MatSnackBarModule,
  MatTableModule
} from "@angular/material";
import {MatSortModule} from '@angular/material/sort';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import {MatRadioModule} from '@angular/material/radio';
import {MatInputModule} from '@angular/material/input';
import { NgModule } from '@angular/core';
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";


@NgModule({
    imports: [
        MatButtonModule,
        MatCheckboxModule,
        MatToolbarModule,
        MatIconModule,
        MatMenuModule,
        MatRadioModule,
        MatInputModule,
        MatSnackBarModule,
        MatTableModule,
        MatDividerModule,
        MatGridListModule,
        MatOptionModule,
        MatSelectModule,
      MatSortModule,
      MatProgressSpinnerModule

    ],
    exports: [
        MatButtonModule,
        MatCheckboxModule,
        MatToolbarModule,
        MatIconModule,
        MatMenuModule,
        MatRadioModule,
        MatInputModule,
      MatSnackBarModule,
      MatTableModule,
      MatDividerModule,
      MatGridListModule,
      MatOptionModule,
      MatSelectModule,
      MatSortModule,
      MatProgressSpinnerModule
    ],
})

export class MaterialModule
{

}

import {
  MatButtonModule,
  MatCheckboxModule,
  MatDividerModule, MatGridListModule,
  MatOptionModule,
  MatSelectModule, MatSnackBarModule,
  MatTableModule
} from "@angular/material";
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import {MatRadioModule} from '@angular/material/radio';
import {MatInputModule} from '@angular/material/input';
import { NgModule } from '@angular/core';


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
        MatSelectModule
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
      MatSelectModule
    ],
})

export class MaterialModule
{

}

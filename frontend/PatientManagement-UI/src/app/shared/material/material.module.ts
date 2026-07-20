import { NgModule } from '@angular/core';

import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';


@NgModule({

    imports: [
        MatTableModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatPaginatorModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatCardModule,
        MatSelectModule
    ],

    exports: [
        MatTableModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatPaginatorModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatCardModule,
        MatSelectModule
    ]

})
export class MaterialModule { }
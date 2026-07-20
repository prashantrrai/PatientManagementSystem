import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';

import { Patient } from '../../../core/models/patient.model';
import { PatientService } from '../../../core/services/patient';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ConfirmDialog } from '../../../shared/confirm-dialog/confirm-dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-patient-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    DatePipe,

    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatDialogModule,
    MatSnackBarModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './patient-list.html',
  styleUrl: './patient-list.scss'
})
export class PatientList implements OnInit {

  private patientService = inject(PatientService);
  private router = inject(Router);
  private dialog = inject(MatDialog);
  private snackBar = inject(MatSnackBar);

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  patients: Patient[] = [];

  displayedColumns: string[] = [
    'name',
    'gender',
    'dateOfBirth',
    'mobileNumber',
    'email',
    'bloodGroup',
    'status',
    'actions'
  ];

  pageNumber = 1;
  pageSize = 10;
  totalRecords = 0;

  searchText = '';
  loading = false;

  ngOnInit(): void {
    this.loadPatients();
  }

  loadPatients(): void {
    this.loading = true;
    this.patientService
      .getPatients(this.pageNumber, this.pageSize, this.searchText)
      .subscribe({
        next: (response) => {
          this.patients = response.items;
          this.totalRecords = response.totalCount;
          this.pageNumber = response.pageNumber;
          this.pageSize = response.pageSize;

          this.loading = false;
        },
        error: () => {
          this.loading = false;

          this.snackBar.open(
            'Unable to load patients.',
            'Close',
            {
              duration: 3000,
              horizontalPosition: 'right',
              verticalPosition: 'top'
            });

        }
      });
  }

  onSearch(): void {
    this.pageNumber = 1;

    if (this.paginator) {
      this.paginator.firstPage();
    }

    this.loadPatients();
  }

  clearSearch(): void {
    this.searchText = '';
    this.pageNumber = 1;
    this.loadPatients();
  }

  pageChanged(event: PageEvent): void {
    this.pageNumber = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.loadPatients();
  }

  addPatient(): void {
    this.router.navigate(['/patients/add']);
  }

  editPatient(id: number): void {
    this.router.navigate(['/patients/edit', id]);
  }

  viewPatient(id: number): void {
    this.router.navigate(['/patients', id]);
  }

  deletePatient(id: number): void {

    const dialogRef = this.dialog.open(ConfirmDialog, {
      width: '400px',
      disableClose: true,
      data: {
        title: 'Delete Patient',
        message: 'Are you sure you want to delete this patient?'
      }
    });

    dialogRef.afterClosed().subscribe(result => {

      if (!result)
        return;

      this.patientService.delete(id).subscribe({
        next: () => {

          this.snackBar.open(
            'Patient deleted successfully.',
            'Close',
            {
              duration: 3000,
              horizontalPosition: 'right',
              verticalPosition: 'top'
            });

          this.loadPatients();
        },
        error: () => {

          this.snackBar.open(
            'Unable to delete patient.',
            'Close',
            {
              duration: 3000,
              horizontalPosition: 'right',
              verticalPosition: 'top'
            });

        }
      });

    });

  }

  getGender(value: number): string {
    switch (value) {
      case 1:
        return 'Male';
      case 2:
        return 'Female';
      case 3:
        return 'Other';
      default:
        return '-';
    }
  }
}
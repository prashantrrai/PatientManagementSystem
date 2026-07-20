import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PatientService } from '../../../core/services/patient';
import { ActivatedRoute, Router } from '@angular/router';
import { futureDateValidator } from '../../../core/validators/future-date.validator';
import { Patient } from '../../../core/models/patient.model';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-patient-form',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCheckboxModule,
    MatSnackBarModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './patient-form.html',
  styleUrl: './patient-form.scss',
})
export class PatientForm {


  private fb = inject(FormBuilder);
  private patientService = inject(PatientService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private snackBar = inject(MatSnackBar);

  isEditMode = false;
  loading = false;
  patientId = 0;

  genders = [
    { value: 1, name: 'Male' },
    { value: 2, name: 'Female' },
    { value: 3, name: 'Other' }
  ];

  bloodGroups = [
    'A+',
    'A-',
    'B+',
    'B-',
    'AB+',
    'AB-',
    'O+',
    'O-'
  ];

  form = this.fb.group({
    patientId: [0],
    firstName: ['', [Validators.required, Validators.maxLength(50)]],
    lastName: ['', Validators.required],
    gender: [0, Validators.required],
    dateOfBirth: ['', [Validators.required, futureDateValidator]],
    mobileNumber: ['', [
      Validators.required,
      Validators.pattern(/^[6-9]\d{9}$/)
    ]],
    email: ['', [Validators.required, Validators.email]],
    bloodGroup: ['', [Validators.required]],
    address: ['', [Validators.required]],
    isActive: [false]
  });

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (!id)
      return;

    this.isEditMode = true;
    this.patientId = +id;
    this.loadPatient();
  }

  loadPatient(): void {
    this.loading = true;

    this.patientService.getById(this.patientId).subscribe({
      next: patient => {
        this.form.patchValue({
          patientId: patient.patientId,
          firstName: patient.firstName,
          lastName: patient.lastName,
          gender: patient.gender,
          dateOfBirth: patient.dateOfBirth,
          mobileNumber: patient.mobileNumber,
          email: patient.email,
          address: patient.address,
          bloodGroup: patient.bloodGroup,
          isActive: patient.isActive
        });

        this.loading = false;
      },
      error: err => {
        console.error(err);
        this.loading = false;
      }
    });
  }

  save(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.loading = true;

    this.patientService.upsert(this.form.value as Patient).subscribe({
      next: () => {
        this.loading = false;

        this.snackBar.open(
          this.isEditMode
            ? 'Patient updated successfully.'
            : 'Patient added successfully.',
          'Close',
          {
            duration: 3000,
            horizontalPosition: 'right',
            verticalPosition: 'top'
          });

        this.router.navigate(['/patients']);
      },
      error: () => {
        this.loading = false;

        this.snackBar.open(
          'Unable to save patient.',
          'Close',
          {
            duration: 3000,
            horizontalPosition: 'right',
            verticalPosition: 'top'
          });
      }
    });
  }

  cancel(): void {
    this.router.navigate(['/patients']);
  }

  get f() {
    return this.form.controls;
  }
}

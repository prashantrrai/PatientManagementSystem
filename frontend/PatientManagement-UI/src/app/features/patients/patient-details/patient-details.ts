import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { Patient } from '../../../core/models/patient.model';
import { PatientService } from '../../../core/services/patient';

@Component({
  selector: 'app-patient-details',
  standalone: true,
  imports: [
    CommonModule,
    DatePipe,
    MatCardModule,
    MatButtonModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './patient-details.html',
  styleUrl: './patient-details.scss'
})
export class PatientDetails implements OnInit {

  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private patientService = inject(PatientService);

  patient?: Patient;
  loading = false;

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id)
      return;

    this.loadPatient(id);
  }

  loadPatient(id: number): void {
    this.loading = true;

    this.patientService.getById(id).subscribe({
      next: res => {
        this.patient = res;
        this.loading = false;
      },
      error: err => {
        console.error(err);
        this.loading = false;
      }
    });
  }

  getGender(value: number): string {
    switch (value) {
      case 1: return 'Male';
      case 2: return 'Female';
      case 3: return 'Other';
      default: return '-';
    }
  }

  back(): void {
    this.router.navigate(['/patients']);
  }
}
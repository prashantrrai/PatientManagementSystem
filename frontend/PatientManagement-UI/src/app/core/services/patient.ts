import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Patient } from '../models/patient.model';
import { Observable } from 'rxjs';
import { PagedResponse } from '../models/paged-response.model';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  constructor(private http: HttpClient) { }

  getPatients(page: number, size: number, search?: string): Observable<PagedResponse<Patient>> {
    return this.http.get<PagedResponse<Patient>>(
      `${environment.apiUrl}/patients?pageNumber=${page}&pageSize=${size}&search=${search ?? ''}`
    );
  }

  getById(id: number): Observable<Patient> {
    return this.http.get<Patient>(
      `${environment.apiUrl}/patients/${id}`
    );
  }

  upsert(patient: Patient): Observable<Patient> {
    return this.http.post<Patient>(
      `${environment.apiUrl}/patients/upsert`,
      patient
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(
      `${environment.apiUrl}/patients/${id}`
    );
  }
}

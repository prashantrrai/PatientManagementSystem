import { Routes } from '@angular/router';
import { PatientList } from './features/patients/patient-list/patient-list';
import { PatientForm } from './features/patients/patient-form/patient-form';
import { PatientDetails } from './features/patients/patient-details/patient-details';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'patients',
        pathMatch: 'full'
    },
    {
        path: 'patients',
        component: PatientList
    },
    {
        path: 'patients/add',
        component: PatientForm
    },
    {
        path: 'patients/edit/:id',
        component: PatientForm
    },
    {
        path: 'patients/:id',
        component: PatientDetails
    }
];

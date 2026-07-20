export interface Patient {
    patientId: number;
    firstName: string;
    lastName: string;
    gender: number;
    dateOfBirth: string;
    mobileNumber: string;
    email: string;
    address: string;
    bloodGroup: string;
    isActive: boolean;
    createdDate?: string;
    modifiedDate?: string | null;
}
import { AbstractControl, ValidationErrors } from '@angular/forms';

export function futureDateValidator(
    control: AbstractControl
): ValidationErrors | null {

    if (!control.value)
        return null;

    const selected = new Date(control.value);

    return selected > new Date()
        ? { futureDate: true }
        : null;
}
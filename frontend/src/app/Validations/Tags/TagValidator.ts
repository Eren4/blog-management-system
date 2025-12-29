import { Validators, ValidatorFn, Validator } from "@angular/forms";

export const TagValidators = {
    tagName : () : ValidatorFn[] => [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(20)
    ]
}
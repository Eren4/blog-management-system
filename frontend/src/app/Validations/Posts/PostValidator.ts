import { Validators, ValidatorFn, Validator } from "@angular/forms";

export const PostValidators = {
    title : () : ValidatorFn[] => [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(20)
    ],
    content : () : ValidatorFn[] => [
        Validators.required
    ],
    excerpt : () : ValidatorFn[] => [
    ],
    publishState : () : ValidatorFn[] => [
        Validators.required
    ]
}
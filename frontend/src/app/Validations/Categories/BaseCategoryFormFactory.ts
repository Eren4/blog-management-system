import { FormControl, Validators } from "@angular/forms";
import { CategoryValidators } from "./CategoryValidator";

export type BaseCategoryFrom = {
    name: FormControl<string>;
    description: FormControl<string>;
};

export function baseCategoryForm(): BaseCategoryFrom {
    return {
        name: new FormControl<string>('', { nonNullable: true, validators: CategoryValidators.name() }),
        description: new FormControl<string>('', { nonNullable: true, validators: CategoryValidators.description() })
    }
}
import { FormControl } from "@angular/forms";
import { TagValidators } from "./TagValidator";

export type BaseTagForm = {
    tagName: FormControl<string>
}

export function baseTagForm(): BaseTagForm {
    return {
        tagName: new FormControl<string>('', { nonNullable: true, validators: TagValidators.tagName() })
    }
}
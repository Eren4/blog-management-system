import { FormControl, FormGroup, Validators } from "@angular/forms";
import { UpdateTagRequestModel } from "../../Models/Tags/UpdateTagRequestModel";
import { baseTagForm } from "./BaseTagFormFactory";

export type UpdateTagForm = FormGroup<{
    id: FormControl<number>;
    tagName: FormControl<string>;
}>;

export function updateTagForm() {
    const base = baseTagForm();

    base.tagName.addValidators([Validators.maxLength(50)]);

    base.tagName.updateValueAndValidity({ emitEvent: false });
    /*
        updateValueAndValidity anlamı: Validator set'i artık değişti
        Angular'a kendini tekrar bir validate et.
        emitEvent:false => valueChanges tekrar tetiklenmesin diye...

        Aksi halde form açıldığı zaman UI'da gereksiz validation event'leri olur
    */

    return new FormGroup({
        id: new FormControl(0, {
            nonNullable: true,
            validators: [Validators.required, Validators.min(1)]
        }),
        ...base
    });
}

export function toUpdateTagRequest(form : UpdateTagForm) : UpdateTagRequestModel {
    return {
        id: form.controls.id.value,
        tagName: form.controls.tagName.value
    };
}
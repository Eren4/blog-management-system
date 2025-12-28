import { FormControl, FormGroup, Validators } from "@angular/forms";
import { UpdatePostRequestModel } from "../../Models/Posts/UpdatePostRequestModel";
import { basePostForm } from "./BasePostFormFactory";
import { PublishState } from "../../Models/Posts/PublishState";

export type UpdatePostForm = FormGroup<{
    id: FormControl<number>;
    title: FormControl<string>;
    content: FormControl<string>;
    excerpt: FormControl<string>;
    publishState: FormControl<PublishState | null>;
}>;

export function updatePostForm() {
    const base = basePostForm();

    // #region
    // Create're dikkat ederseniz maxLength yok... Update'de validation logic değişiyor...
    // Aynı FormControl
    // #endregion

    base.title.addValidators([Validators.maxLength(50)]);

    base.title.updateValueAndValidity({ emitEvent: false });
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

export function toUpdatePostRequest(form : UpdatePostForm) : UpdatePostRequestModel {
    return {
        id: form.controls.id.value,
        title: form.controls.title.value,
        content: form.controls.content.value,
        excerpt: form.controls.excerpt.value,
        publishState: form.controls.publishState.value
    };
}
import { FormGroup } from "@angular/forms";
import { CreateTagRequestModel } from "../../Models/Tags/CreateTagRequestModel";
import { baseTagForm } from "./BaseTagFormFactory";

export type CreateTagForm = FormGroup<ReturnType<typeof baseTagForm>>;

export function createTagForm(): CreateTagForm {
    return new FormGroup(baseTagForm());
}

export function toCreateTagRequest(form: CreateTagForm) : CreateTagRequestModel {
    return {
        tagName: form.controls.tagName.value
    }
}
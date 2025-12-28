import { FormGroup } from "@angular/forms";
import { CreatePostRequestModel } from "../../Models/Posts/CreatePostRequestModel";
import { basePostForm } from "./BasePostFormFactory";

export type CreatePostForm = FormGroup<ReturnType<typeof basePostForm>>;

export function createPostForm(): CreatePostForm {
    return new FormGroup(basePostForm());
}

export function toCreatePostRequest(form: CreatePostForm) : CreatePostRequestModel {
    return {
        title: form.controls.title.value,
        content: form.controls.content.value,
        excerpt: form.controls.excerpt.value,
        publishState: form.controls.publishState.value
    }
}
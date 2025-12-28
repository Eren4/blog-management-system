import { FormControl } from "@angular/forms";
import { PostValidators } from "./PostValidator";
import { PublishState } from "../../Models/Posts/PublishState";

export type BasePostForm = {
    title: FormControl<string>;
    content: FormControl<string>;
    excerpt: FormControl<string>;
    publishState: FormControl<PublishState | null>;
}

export function basePostForm(): BasePostForm {
    return {
        title: new FormControl<string>('', { nonNullable: true, validators: PostValidators.title() }),
        content: new FormControl<string>('', { nonNullable: true, validators: PostValidators.content() }),
        excerpt: new FormControl<string>('', { nonNullable: true, validators: PostValidators.excerpt() }),
        publishState: new FormControl<PublishState | null>(null, { validators: PostValidators.publishState() })
    }
}
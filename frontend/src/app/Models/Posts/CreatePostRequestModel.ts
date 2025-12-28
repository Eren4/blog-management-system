import { BasePostViewModel } from "./BasePostViewModel";
import { PublishState } from "./PublishState";

export class CreatePostRequestModel extends BasePostViewModel {
    constructor(title: string, content: string, excerpt: string, publishState: PublishState) {
        super(title, content, excerpt, publishState);
    }
}
import { BasePostViewModel } from "./BasePostViewModel";
import { PublishState } from "./PublishState";

export class PostResponseModel extends BasePostViewModel {
    id: number;
    
    constructor(id: number, title: string, content: string, excerpt: string, publishState: PublishState) {
        super(title, content, excerpt, publishState);
        this.id = id;
    }
}
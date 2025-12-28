import { PublishState } from "./PublishState";

export abstract class BasePostViewModel {
    title: string;
    content: string;
    excerpt: string;
    publishState: PublishState | null;

    constructor(title: string, content: string, excerpt: string, publishState: PublishState) {
        this.title = title;
        this.content = content;
        this.excerpt = excerpt;
        this.publishState = publishState;
    }
}
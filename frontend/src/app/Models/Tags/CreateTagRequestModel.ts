import { BaseTagViewModel } from "./BaseTagViewModel";

export class CreateTagRequestModel extends BaseTagViewModel {
    constructor(tagName: string) {
        super(tagName);
    }
}
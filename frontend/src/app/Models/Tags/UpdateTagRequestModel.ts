import { BaseTagViewModel } from "./BaseTagViewModel";

export class UpdateTagRequestModel extends BaseTagViewModel {
    id: number;

    constructor(id: number, tagName: string) {
        super(tagName);
        this.id = id;
    }
}
import { BaseTagViewModel } from "./BaseTagViewModel";

export class TagResponseModel extends BaseTagViewModel {
    id: number;
    
    constructor(id: number, tagName: string) {
        super(tagName);
        this.id = id;
    }
}
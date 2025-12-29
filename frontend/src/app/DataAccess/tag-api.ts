import { Injectable, inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { last, lastValueFrom } from "rxjs";
import { API_Config } from "../api.config";
import { TagResponseModel } from "../Models/Tags/TagResponseModel";
import { CreateTagRequestModel } from "../Models/Tags/CreateTagRequestModel";
import { UpdateTagRequestModel } from "../Models/Tags/UpdateTagRequestModel";

@Injectable({providedIn: 'root'})
export class TagApi {
    private http = inject(HttpClient);
    private readonly url = `${API_Config.baseURL}/${API_Config.endpoints.tag}`;

    // Get List
    async getAll() : Promise<TagResponseModel[]> {
        return await lastValueFrom(this.http.get<TagResponseModel[]>(this.url));
    }

    // Post : Create
    async create(body : CreateTagRequestModel) : Promise<string> {
        return await lastValueFrom(this.http.post(this.url, body, {
            responseType: 'text'
        }));
    }

    // Put : Update
    async update(body : UpdateTagRequestModel): Promise<string> {
        return await lastValueFrom(this.http.put(`${this.url}/${body.id}`, body, { responseType: 'text' }));
    }

    // Delete
    async deleteById(id : number): Promise<string> {
        return await lastValueFrom(this.http.delete(`${this.url}/${id}`, { body: id, responseType: 'text' }));
    }
}
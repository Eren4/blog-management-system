import { Injectable, inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { last, lastValueFrom } from "rxjs";
import { API_Config } from "../api.config";
import { PostResponseModel } from "../Models/Posts/PostResponseModel";
import { CreatePostRequestModel } from "../Models/Posts/CreatePostRequestModel";
import { UpdatePostRequestModel } from "../Models/Posts/UpdatePostRequestModel";

@Injectable({providedIn: 'root'})
export class PostApi {
    private http = inject(HttpClient);
    private readonly url = `${API_Config.baseURL}/${API_Config.endpoints.post}`;

    // Get List
    async getAll() : Promise<PostResponseModel[]> {
        return await lastValueFrom(this.http.get<PostResponseModel[]>(this.url));
    }

    // Post : Create
    async create(body : CreatePostRequestModel) : Promise<string> {
        return await lastValueFrom(this.http.post(this.url, body, {
            responseType: 'text'
        }));
    }

    // Put : Update
    async update(body : UpdatePostRequestModel): Promise<string> {
        return await lastValueFrom(this.http.put(`${this.url}/${body.id}`, body, { responseType: 'text' }));
    }

    // Delete
    async deleteById(id : number): Promise<string> {
        return await lastValueFrom(this.http.delete(`${this.url}/${id}`, { body: id, responseType: 'text' }));
    }
}
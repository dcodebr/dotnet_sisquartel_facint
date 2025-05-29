import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";
import { Militar } from "../models/militar.model";

@Injectable({
    providedIn: 'root'
})
export class MilitarService extends BaseService<Militar> {
    protected override modulo: String = "militares";
    
    constructor(httpClient: HttpClient) {
        super(httpClient);        
    }
}
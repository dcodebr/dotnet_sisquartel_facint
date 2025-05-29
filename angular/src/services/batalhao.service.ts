import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { Batalhao } from "../models/batalhao.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class BatalhaoService extends BaseService<Batalhao> {
    protected override modulo: String = "batalhao";
    
    constructor(httpClient: HttpClient) {
        super(httpClient);        
    }
}
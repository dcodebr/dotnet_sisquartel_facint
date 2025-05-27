import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { Patente } from "../models/patente.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class PatenteService extends BaseService<Patente> {
    protected override modulo: String = "patente";
    
    constructor(httpClient: HttpClient) {
        super(httpClient);        
    }
}
import { Observable } from "rxjs";
import { PatenteModel } from "../models/patente.model";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class PatenteService {

    constructor(private httpClient: HttpClient) {
    }

    public retornarTodos(): Observable<PatenteModel[]> {
        let resultado = this.httpClient.get<PatenteModel[]>("https://localhost:7074/api/Patente");
        return resultado;
    }
}
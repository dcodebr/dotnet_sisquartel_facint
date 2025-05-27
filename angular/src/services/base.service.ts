import { HttpClient } from "@angular/common/http";
import { BaseModel } from "../models/base.model";
import { Observable } from "rxjs";

export abstract class BaseService<T extends BaseModel> {
    private baseRoute = "https://localhost:7074/api"
    protected abstract modulo: String;

    public get route() : string {
        return `${this.baseRoute}/${this.modulo}`;
    }

    constructor(private httpClient: HttpClient) {
    }

    public retornarTodos(): Observable<T[]> {
        let result = this.httpClient.get<T[]>(this.route);
        return result;
    }

    public retornarPorId(id: Number): Observable<T> {
        let result = this.httpClient.get<T>(`${this.route}/${id}`);
        return result;
    }

    public adicionar(objeto: T) : Observable<T> {
        let result = this.httpClient.post<T>(this.route, objeto);
        return result;
    }

    public atualizar(id: Number, objeto: T): Observable<T> {
        let result = this.httpClient.put<T>(`${this.route}/${id}`, objeto);
        return result;
    }

    public excluir(id: Number): Observable<Object> {
        let result = this.httpClient.delete(`${this.route}/${id}`);
        return result;
    }
}
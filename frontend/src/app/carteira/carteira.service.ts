import { Carteira } from "../model/Carteira";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";


@Injectable()
export class CarteiraService {
    constructor(private http: HttpClient) {}

    public getTodasCarteira(): Observable<Carteira[]> {
        return this.http.get<Carteira[]>(`${environment.baseUrl}Carteira/ListarTodos`);
    }

    






}
import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'any'})

export class GetRestoranByIdVlasnikaEndpoint implements MyBaseEndpoint<number, RestoranGetByIDVlasnik> {

    constructor(public httpClient:HttpClient) {

    }


    akcija(request: number): Observable<RestoranGetByIDVlasnik> {
        let url=MojConfig.adresa_servera+`/Restoran-GetByIDVlasnik?ID=${request}`;

        return this.httpClient.get<RestoranGetByIDVlasnik>(url);
    }

}

export interface RestoranGetByIDVlasnik {
    restoran: RestoranGetByIDVlasnikRestoran[]
}

export interface RestoranGetByIDVlasnikRestoran {
    id: number
    naziv: string
    radnoVrijemeOd: string
    radnoVrijemeDo: string
    opis: string
    slikaRestorana: string
}

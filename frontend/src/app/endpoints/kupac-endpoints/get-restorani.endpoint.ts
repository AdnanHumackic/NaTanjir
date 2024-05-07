import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn:'any'})

export class GetRestoraniEndpoint implements MyBaseEndpoint<void, RestoraniGetResponse>{

  constructor(public httpClient:HttpClient) {
  }
  akcija(request:void): Observable<RestoraniGetResponse> {
    let url = MojConfig.adresa_servera + `/Kupac-GetRestorani`;

    return this.httpClient.get<RestoraniGetResponse>(url);
  }
}


export interface RestoraniGetResponse {
  restorani: RestoraniGetResponseRestoran[]
  brojRestorana: number
}

export interface RestoraniGetResponseRestoran{
  id: number
  naziv: string
  radnoVrijemeOd: string
  radnoVrijemeDo: string
  opis: string
  slikaRestorana: any
  isObrisan: boolean
  lokacija: string
  imePrezimeVlasnika: string
}

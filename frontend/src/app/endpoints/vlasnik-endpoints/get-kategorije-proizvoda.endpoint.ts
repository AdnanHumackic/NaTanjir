import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn:'any'})

export class GetKategorijeProizvodaEndpoint implements MyBaseEndpoint<void, KategorijeProizvodaGetAllResponse>{

  constructor(public httpClient:HttpClient) {
  }

  akcija(request: void): Observable<KategorijeProizvodaGetAllResponse> {
    let url=MojConfig.adresa_servera+`/Vlasnik-GetKategorijeProizvoda`;

    return this.httpClient.get<KategorijeProizvodaGetAllResponse>(url);
  }

}

export interface KategorijeProizvodaGetAllResponse {
  kategorije: KategorijeProizvodaGetAllResponseKategorije[]
}

export interface KategorijeProizvodaGetAllResponseKategorije {
  id: number
  naziv: string
}

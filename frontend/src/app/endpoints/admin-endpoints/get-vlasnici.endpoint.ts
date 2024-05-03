import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn:'any'})

export class GetVlasniciEndpoint implements MyBaseEndpoint<void, VlasnikGetAllResponse>{

  constructor(public httpClient:HttpClient) {
  }
  akcija(request: void): Observable<any> {
    let url=MojConfig.adresa_servera+`/Admin-GetVlasnici`;

    return this.httpClient.get<VlasnikGetAllResponse>(url);
  }

}
export interface VlasnikGetAllResponse {
  vlasnik: VlasnikGetAllResponseVlasnik[]
}

export interface VlasnikGetAllResponseVlasnik {
  id: number
  imePrezime: string
}

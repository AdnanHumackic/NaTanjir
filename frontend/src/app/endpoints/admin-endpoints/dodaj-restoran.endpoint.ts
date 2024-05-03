import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn:'any'})

export class DodajRestoranEndpoint implements MyBaseEndpoint<any, number>{

  constructor(public httpClient:HttpClient) {
  }

  akcija(request: any): Observable<number> {
    let url=MojConfig.adresa_servera+`/Admin-DodajRestoran`;

    return this.httpClient.post<number>(url, request);

  }

}

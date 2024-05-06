import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn:'any'})

export class DodajProizvodEndpoint implements MyBaseEndpoint<any, number>{

  constructor(public httpClient:HttpClient) {
  }

  akcija(request: any): Observable<number> {
    let url=MojConfig.adresa_servera+`/Vlasnik-DodajHranu`;

    return this.httpClient.post<number>(url, request);
  }
}

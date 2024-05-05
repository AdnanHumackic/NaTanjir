import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn:'any'})

export class UpdateRestoranEndpoint implements MyBaseEndpoint<any, number>{

  constructor(public httpClient:HttpClient) {

  }

  akcija(request: any): Observable<number> {
    let url=MojConfig.adresa_servera+`/Vlasnik-UpdateRestoran`;

    return this.httpClient.post<number>(url, request);

  }

}

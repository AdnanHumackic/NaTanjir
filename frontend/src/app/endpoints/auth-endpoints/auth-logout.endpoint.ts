import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'any'})

export class AuthLogoutEndpoint implements MyBaseEndpoint<void, void>{

  constructor(public httpClient:HttpClient) {
  }
  akcija(request: void): Observable<void> {
    let url=MojConfig.adresa_servera+`/Auth/Logout`;
    return this.httpClient.post<void>(url, {});
  }

}

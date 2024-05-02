import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {AutentifikacijaToken} from "../../helper/autentifikacijaToken";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import { Injectable } from "@angular/core";

@Injectable({providedIn: 'any'})
export class AuthLoginEndpoint implements  MyBaseEndpoint<AuthLoginRequest, AuthLoginResponse>{

  constructor(public httpClient:HttpClient) {
  }

  akcija(request: AuthLoginRequest): Observable<AuthLoginResponse> {
    let url=MojConfig.adresa_servera+`/Auth/Login`;
    return this.httpClient.post<AuthLoginResponse>(url, request);
  }


}

export interface AuthLoginRequest {
  korisnickoIme: string;
  lozinka: string;
}

export interface AuthLoginResponse {
  autentifikacijaToken: AutentifikacijaToken
  isLogiran: boolean
}

import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {AutentifikacijaToken} from "../helper/autentifikacijaToken";

@Injectable({providedIn:'root'})

export class MyAuthService{
  constructor() {
  }

  isLogiran():boolean{
    return this.getAuthorizationToken()!=null;
  }
  getAuthorizationToken():AutentifikacijaToken | null {
    let tokenString = window.localStorage.getItem("my-auth-token")??"";
    try {
      return JSON.parse(tokenString);
    }
    catch (e){
      return null;
    }
  }
  isAdmin():boolean {
    return this.getAuthorizationToken()?.korisnickiNalog.isAdmin ?? false
  }
  isKupac():boolean {
    return this.getAuthorizationToken()?.korisnickiNalog.isKupac ?? false
  }
  isRadnik():boolean {
    return this.getAuthorizationToken()?.korisnickiNalog.isRadnik ?? false
  }
  isVlasnik():boolean {
    return this.getAuthorizationToken()?.korisnickiNalog.isVlasnik ?? false
  }
  setLogiraniKorisnik(x: AutentifikacijaToken | null) {

    if (x == null){
      window.localStorage.setItem("my-auth-token", '');
    }
    else {
      window.localStorage.setItem("my-auth-token", JSON.stringify(x));
    }
  }
}

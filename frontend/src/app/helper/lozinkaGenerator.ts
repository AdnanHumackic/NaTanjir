import {Injectable} from "@angular/core";

@Injectable({providedIn:'root'})

export class LozinkaGenerator{
  generisiLozinku() {
    const minLength = 6;
    const maxLength = 12;
    const length = Math.floor(Math.random() * (maxLength - minLength + 1)) + minLength;
    const charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    let sifra = "";

    for (let i = 0; i < length; i++) {
      const randomIndex = Math.floor(Math.random() * charset.length);
      sifra += charset[randomIndex];
    }
  }
}

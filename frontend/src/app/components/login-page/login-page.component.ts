import {Component} from '@angular/core';
import {Router, RouterLink} from "@angular/router";
import {
  AuthLoginEndpoint,
  AuthLoginRequest,
} from "../../endpoints/auth-endpoints/auth-login.endpoint";
import {MyAuthService} from "../../services/MyAuthService";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule,
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {

  public loginRequest: AuthLoginRequest = {
    lozinka: "",
    korisnickoIme: "",
  };

  constructor(private router:Router, private myAuth:MyAuthService, private authLoginEndpoint:AuthLoginEndpoint) {
  }


  prijaviSe() {
    this.authLoginEndpoint.akcija(this.loginRequest).subscribe((x)=>{
      if(!x.isLogiran){
        alert("wrong username/pass")
      }
      else{
        this.myAuth.setLogiraniKorisnik(x.autentifikacijaToken);
        alert("success")
      }
    })
  }
}

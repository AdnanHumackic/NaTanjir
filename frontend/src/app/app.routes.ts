import {Routes} from '@angular/router';
import {PocetnaStranicaComponent} from "./components/pocetna-stranica/pocetna-stranica.component";
import {LoginPageComponent} from "./components/login-page/login-page.component";


export const routes: Routes = [
  {path: '', component: PocetnaStranicaComponent, pathMatch: 'full'},
  {path: 'prijaviSe', component: LoginPageComponent},

];

import {Routes} from '@angular/router';
import {PocetnaStranicaComponent} from "./components/pocetna-stranica/pocetna-stranica.component";
import {LoginPageComponent} from "./components/login-page/login-page.component";
import {AdminPanelNavBarComponent} from "./components/admin-panel-nav-bar/admin-panel-nav-bar.component";
import {DodavanjeVlasnikaComponent} from "./components/dodavanje-vlasnika/dodavanje-vlasnika.component";


export const routes: Routes = [
  {path: '', component: PocetnaStranicaComponent, pathMatch: 'full'},
  {path: 'prijaviSe', component: LoginPageComponent},
  {path: 'adminPanel/dodavanjeVlasnikaRestorana', component: DodavanjeVlasnikaComponent},

];

import {Routes} from '@angular/router';
import {PocetnaStranicaComponent} from "./components/pocetna-stranica/pocetna-stranica.component";
import {LoginPageComponent} from "./components/login-page/login-page.component";
import {AdminPanelNavBarComponent} from "./components/admin-panel-nav-bar/admin-panel-nav-bar.component";
import {DodavanjeVlasnikaComponent} from "./components/dodavanje-vlasnika/dodavanje-vlasnika.component";
import {DodajRestoranEndpoint} from "./endpoints/admin-endpoints/dodaj-restoran.endpoint";
import {DodavanjeRestoranaComponent} from "./components/dodavanje-restorana/dodavanje-restorana.component";
import {UpravljanjeRestoranimaComponent} from "./components/upravljanje-restoranima/upravljanje-restoranima.component";
import {RegistrationPageComponent} from "./components/registration-page/registration-page.component";


export const routes: Routes = [
  {path: '', component: PocetnaStranicaComponent, pathMatch: 'full'},
  {path: 'prijaviSe', component: LoginPageComponent},
  {path: 'registrujSe', component: RegistrationPageComponent},
  {path: 'adminPanel/dodavanjeVlasnikaRestorana', component: DodavanjeVlasnikaComponent},
  {path: 'adminPanel/dodavanjeRestorana', component: DodavanjeRestoranaComponent},
  {path: 'vlasnikPanel/upravljanjeRestoranima/:id', component: UpravljanjeRestoranimaComponent},

];

import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-pocetna-stranica',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './pocetna-stranica.component.html',
  styleUrl: './pocetna-stranica.component.css'
})
export class PocetnaStranicaComponent {

}

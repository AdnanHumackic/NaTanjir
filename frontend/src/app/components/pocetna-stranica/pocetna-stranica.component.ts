import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";
import {MyAuthService} from "../../services/MyAuthService";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-pocetna-stranica',
  standalone: true,
  imports: [
    RouterLink,
    NgIf
  ],
  templateUrl: './pocetna-stranica.component.html',
  styleUrl: './pocetna-stranica.component.css'
})
export class PocetnaStranicaComponent {

  constructor(public myAuth:MyAuthService) {
  }
}

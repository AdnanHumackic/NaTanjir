import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";
import {MyAuthService} from "../../services/MyAuthService";

@Component({
  selector: 'app-vlasnik-panel-navbar',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './vlasnik-panel-navbar.component.html',
  styleUrl: './vlasnik-panel-navbar.component.css'
})
export class VlasnikPanelNavbarComponent {

  constructor(public myAuth:MyAuthService) {
  }
}

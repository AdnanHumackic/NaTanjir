import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";
import {DodavanjeVlasnikaComponent} from "../dodavanje-vlasnika/dodavanje-vlasnika.component";

@Component({
  selector: 'app-admin-panel-nav-bar',
  standalone: true,
  imports: [
    RouterLink,
    DodavanjeVlasnikaComponent,
  ],
  templateUrl: './admin-panel-nav-bar.component.html',
  styleUrl: './admin-panel-nav-bar.component.css'
})
export class AdminPanelNavBarComponent {

}

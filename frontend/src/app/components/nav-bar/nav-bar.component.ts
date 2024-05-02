import {Component, OnInit} from '@angular/core';
import {RouterLink, RouterOutlet} from "@angular/router";
import {MyAuthService} from "../../services/MyAuthService";
import {NgIf} from "@angular/common";
import {AuthLogoutEndpoint} from "../../endpoints/auth-endpoints/auth-logout.endpoint";
declare function init_plugin():any;

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    NgIf
  ],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit{

  constructor(public myAuth:MyAuthService, private authLogoutEndpoint:AuthLogoutEndpoint) {
  }
  ngOnInit(): void {
    init_plugin();
  }

  odjaviSe() {
    let token = window.localStorage.getItem("my-auth-token") ?? "";
    this.authLogoutEndpoint.akcija().subscribe(()=>{
      window.localStorage.removeItem("my-auth-token");
      alert("success")
    })

  }
}

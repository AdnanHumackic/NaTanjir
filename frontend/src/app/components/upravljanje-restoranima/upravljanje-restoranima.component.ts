import {Component, OnInit} from '@angular/core';
import {VlasnikPanelNavbarComponent} from "../vlasnik-panel-navbar/vlasnik-panel-navbar.component";
import {
  GetRestoranByIdVlasnikaEndpoint,
  RestoranGetByIDVlasnikRestoran
} from "../../endpoints/restoran-endpoints/get-restoran-by-id-vlasnika.endpoint";
import {ActivatedRoute} from "@angular/router";
import {NgForOf} from "@angular/common";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-upravljanje-restoranima',
  standalone: true,
  imports: [
    VlasnikPanelNavbarComponent,
    NgForOf
  ],
  templateUrl: './upravljanje-restoranima.component.html',
  styleUrl: './upravljanje-restoranima.component.css'
})
export class UpravljanjeRestoranimaComponent implements OnInit{

  vlasnikId:any;
  restoran:RestoranGetByIDVlasnikRestoran[]=[];
  constructor(private getRestoranByIDVlasnikEndpoint:GetRestoranByIdVlasnikaEndpoint, private activatedRoute:ActivatedRoute) {
  }

  ngOnInit(): void {
    this.vlasnikId=this.activatedRoute.snapshot.params["id"];
    this.fetchRestorani();

  }

  fetchRestorani(){
    this.getRestoranByIDVlasnikEndpoint.akcija(this.vlasnikId).subscribe(x=>{
      this.restoran=x.restoran;
    })
  }

  protected readonly MojConfig = MojConfig;
}

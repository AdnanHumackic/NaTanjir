import {Component, OnInit} from '@angular/core';
import {VlasnikPanelNavbarComponent} from "../vlasnik-panel-navbar/vlasnik-panel-navbar.component";
import {
  GetRestoranByIdVlasnikaEndpoint,
  RestoranGetByIDVlasnikRestoran
} from "../../endpoints/restoran-endpoints/get-restoran-by-id-vlasnika.endpoint";
import {ActivatedRoute} from "@angular/router";
import {NgForOf} from "@angular/common";
import {MojConfig} from "../../moj-config";
import {DodavanjeRadnikaComponent} from "../dodavanje-radnika/dodavanje-radnika.component";
import {UpdateRestoranComponent} from "../update-restoran/update-restoran.component";
import {timestamp} from "rxjs";
import {DodavanjeProizvodaComponent} from "../dodavanje-proizvoda/dodavanje-proizvoda.component";

@Component({
  selector: 'app-upravljanje-restoranima',
  standalone: true,
  imports: [
    VlasnikPanelNavbarComponent,
    NgForOf,
    DodavanjeRadnikaComponent,
    UpdateRestoranComponent,
    DodavanjeProizvodaComponent
  ],
  templateUrl: './upravljanje-restoranima.component.html',
  styleUrl: './upravljanje-restoranima.component.css'
})
export class UpravljanjeRestoranimaComponent implements OnInit{

  vlasnikId:any;
  restoran:RestoranGetByIDVlasnikRestoran[]=[];
  odabraniRestoran:any=null;
  odabraniRestoranUpdate:any=null;
  odabraniRestoranProizvod:any=null;

  protected readonly timestamp = timestamp;
  protected readonly Date = Date;
  refreshTimestamp: number = Date.now();
  protected readonly MojConfig = MojConfig;

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


  dodajRadnika(id: number, naziv: string) {
    this.odabraniRestoran={id,naziv};
  }

  updateRestoran(rest: RestoranGetByIDVlasnikRestoran) {
    this.odabraniRestoranUpdate=rest;
  }


  dodajProizvod(id: number, naziv: string) {
    this.odabraniRestoranProizvod={id, naziv};
  }
}

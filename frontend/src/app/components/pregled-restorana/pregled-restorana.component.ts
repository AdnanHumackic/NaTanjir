import {Component, OnInit} from '@angular/core';
import {
  GetRestoraniEndpoint,
  RestoraniGetResponseRestoran
} from "../../endpoints/kupac-endpoints/get-restorani.endpoint";
import {NgForOf} from "@angular/common";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-pregled-restorana',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './pregled-restorana.component.html',
  styleUrl: './pregled-restorana.component.css'
})
export class PregledRestoranaComponent implements OnInit{

  restorani:RestoraniGetResponseRestoran[]=[];
  brojRestorana!:number;
  protected readonly MojConfig = MojConfig;
  refreshTimestamp: number = Date.now();
  constructor(private getRestoraniEndpoint:GetRestoraniEndpoint) {
  }

  ngOnInit(): void {
    this.fetchRestorani();
  }

  fetchRestorani() {
    this.getRestoraniEndpoint.akcija().subscribe(x=>{
      this.restorani=x.restorani;
      this.brojRestorana=x.brojRestorana;
    })
  }


}

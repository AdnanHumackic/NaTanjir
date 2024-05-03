import {Component, OnInit} from '@angular/core';
import {AdminPanelNavBarComponent} from "../admin-panel-nav-bar/admin-panel-nav-bar.component";
import {GetVlasniciEndpoint, VlasnikGetAllResponseVlasnik} from "../../endpoints/admin-endpoints/get-vlasnici.endpoint";
import {NgForOf, NgIf} from "@angular/common";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {DodajRestoranEndpoint} from "../../endpoints/admin-endpoints/dodaj-restoran.endpoint";

@Component({
  selector: 'app-dodavanje-restorana',
  standalone: true,
  imports: [
    AdminPanelNavBarComponent,
    NgForOf,
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './dodavanje-restorana.component.html',
  styleUrl: './dodavanje-restorana.component.css'
})
export class DodavanjeRestoranaComponent implements OnInit{

  constructor(private dohvatiVlasnikaEndpoint:GetVlasniciEndpoint, private dodajRestoranEndpoint:DodajRestoranEndpoint) {
  }
  vlasnik:VlasnikGetAllResponseVlasnik[]=[];
  dodavanjeRestoranaForm=new FormGroup({
    naziv:new FormControl('', Validators.required),
    radnoVrijemeOd:new FormControl('', [Validators.required, Validators.pattern(/^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/)]),
    radnoVrijemeDo:new FormControl('', [Validators.required, Validators.pattern(/^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/)]),
    opis:new FormControl('', Validators.required),
    vlasnikRestoranaID:new FormControl('', Validators.required),
  });

  ngOnInit(): void {
    this.fetchVlasnici();
  }

  fetchVlasnici(){
    this.dohvatiVlasnikaEndpoint.akcija()
      .subscribe(x=>{
        this.vlasnik=x.vlasnik;
      })
  }


  dodajRestoran() {
    const formData={
      naziv:this.dodavanjeRestoranaForm.get('naziv')?.value,
      radnoVrijemeOd:this.dodavanjeRestoranaForm.get('radnoVrijemeOd')?.value,
      radnoVrijemeDo:this.dodavanjeRestoranaForm.get('radnoVrijemeDo')?.value,
      opis:this.dodavanjeRestoranaForm.get('opis')?.value,
      vlasnikRestoranaID:this.dodavanjeRestoranaForm.get('vlasnikRestoranaID')?.value
    };
    if(this.dodavanjeRestoranaForm.valid){
      this.dodajRestoranEndpoint.akcija(formData).subscribe(x=>{
        alert("Success");
        this.dodavanjeRestoranaForm.reset();
      })
    }
    else{
      alert("error");
    }
  }
}

import {Component, Input, OnInit} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {
  GetKategorijeProizvodaEndpoint,
  KategorijeProizvodaGetAllResponse, KategorijeProizvodaGetAllResponseKategorije
} from "../../endpoints/vlasnik-endpoints/get-kategorije-proizvoda.endpoint";
import {ImageService} from "../../services/image-service";
import {DodajProizvodEndpoint} from "../../endpoints/vlasnik-endpoints/dodaj-proizvod.endpoint";
import {visitAll} from "@angular/compiler";

@Component({
  selector: 'app-dodavanje-proizvoda',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    NgForOf
  ],
  templateUrl: './dodavanje-proizvoda.component.html',
  styleUrl: './dodavanje-proizvoda.component.css'
})
export class DodavanjeProizvodaComponent implements OnInit {

  @Input() dodajProizvod: any;
  kategorija: KategorijeProizvodaGetAllResponseKategorije[] = [];

  constructor(private getKategorijeProizvodaEndpoint: GetKategorijeProizvodaEndpoint, public imageService: ImageService,
              private dodajProizvodEndpoint: DodajProizvodEndpoint) {
  }

  ngOnInit(): void {
    this.fetchKategorije();
  }

  fetchKategorije() {
    this.getKategorijeProizvodaEndpoint.akcija()
      .subscribe(x => {
        this.kategorija = x.kategorije;
      })
  }

  dodajProizvodForm = new FormGroup({
    nazivProizvoda: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[A-Z][a-zA-Z0-9_ ]*$/)
    ]),
    sastojci: new FormControl('', [Validators.required]),
    isUPonudi: new FormControl('', [Validators.required]),
    vrijemePripreme: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[0-9]+$/)
    ]),
    slikaProizvoda: new FormControl(''),
    kategorijaID: new FormControl('', [Validators.required]),
    restoranID: new FormControl(''),
    cijenaProizvoda: new FormControl('', [
      Validators.required,
      Validators.pattern(/^\d+(\.\d{1,2})?$/)
    ])
  });

  zatvoriDodavanje() {
    this.dodajProizvod = null;
  }

  dodavanjeProizvoda() {

    const formData = {
      nazivProizvoda: this.dodajProizvodForm.get('nazivProizvoda')?.value,
      sastojci: this.dodajProizvodForm.get('sastojci')?.value,
      isUPonudi: this.dodajProizvodForm.get('isUPonudi')?.value,
      vrijemePripreme: this.dodajProizvodForm.get('vrijemePripreme')?.value,
      slikaProizvoda: this.imageService.vrijednost || null,
      kategorijaID: this.dodajProizvodForm.get('kategorijaID')?.value,
      restoranID: this.dodajProizvod.id,
      cijenaProizvoda: this.dodajProizvodForm.get('cijenaProizvoda')?.value,
    }
    if (this.dodajProizvodForm.valid) {
      this.dodajProizvodEndpoint.akcija(formData).subscribe(x => {
        alert("brao");
        this.dodajProizvodForm.reset();
      })
    } else {
      alert("error");
    }

  }


}

import {Component, EventEmitter, Input, OnChanges, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {NgForOf, NgIf} from "@angular/common";
import {UpdateRestoranEndpoint} from "../../endpoints/vlasnik-endpoints/update-restoran.endpoint";

@Component({
  selector: 'app-update-restoran',
  standalone: true,
  imports: [
    FormsModule,
    NgIf,
    ReactiveFormsModule,
    NgForOf
  ],
  templateUrl: './update-restoran.component.html',
  styleUrl: './update-restoran.component.css'
})
export class UpdateRestoranComponent implements OnChanges {

  @Input() updateRestoran: any;
  @Output() zatvaranjeModala: EventEmitter<void> = new EventEmitter();


  constructor(private updateRestoranEndpoint: UpdateRestoranEndpoint) {
  }

  updateRestoranForm = new FormGroup({
    naziv:new FormControl('', Validators.required),
    radnoVrijemeOd:new FormControl('', [Validators.required, Validators.pattern(/^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/)]),
    radnoVrijemeDo:new FormControl('', [Validators.required, Validators.pattern(/^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/)]),
    opis:new FormControl('', Validators.required),
    id:new FormControl(),
    lokacija: new FormControl('', [Validators.required, Validators.pattern(/^([A-Za-z]+\s*)+$/)]),
    slikaRestorana:new FormControl(''),
  });


  //try to change approach
  ngOnChanges() {
    if (this.updateRestoran) {
      this.updateRestoranForm.setValue({
        id: this.updateRestoran.id || null,
        naziv: this.updateRestoran.naziv || null,
        radnoVrijemeOd: this.updateRestoran.radnoVrijemeOd || null,
        radnoVrijemeDo: this.updateRestoran.radnoVrijemeDo || null,
        opis: this.updateRestoran.opis || null,
        slikaRestorana: this.updateRestoran.slikaRestorana || null,
        lokacija: this.updateRestoran.lokacija || null,
      });
    }
  }


  zatvoriUpdate() {
    this.updateRestoran = null;
    this.updateRestoranForm.reset();
    this.zatvaranjeModala.emit();
  }

  restoranUpdate() {
    const formData = {
      id: this.updateRestoran.id,
      naziv: this.updateRestoranForm.get('naziv')?.value,
      radnoVrijemeOd: this.updateRestoranForm.get('radnoVrijemeOd')?.value,
      radnoVrijemeDo: this.updateRestoranForm.get('radnoVrijemeDo')?.value,
      opis: this.updateRestoranForm.get('opis')?.value,
      slikaRestorana: this.vrijednost,
      lokacija: this.updateRestoranForm.get('lokacija')?.value,
    }
    if (this.updateRestoranForm.valid) {
      this.updateRestoranEndpoint.akcija(formData).subscribe(x => {
        alert("brao");
      })
    } else {
      alert("error")
    }

  }


  //move this to helper
  vrijednost!: any;

  generisiPreview() {

    // @ts-ignore
    var file = document.getElementById("slikaRestorana").files[0];
    if (file && this.updateRestoranForm) {
      var reader = new FileReader();
      reader.onload = () => {
        this.vrijednost = reader.result?.toString();
      };
      reader.readAsDataURL(file);
    }
  }
}

import {Component, input} from '@angular/core';
import {AdminPanelNavBarComponent} from "../admin-panel-nav-bar/admin-panel-nav-bar.component";
import {
  AbstractControl,
  FormControl,
  FormGroup,
  isFormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators
} from "@angular/forms";
import {DodajVlasnikaEndpoint} from "../../endpoints/admin-endpoints/dodaj-vlasnika.endpoint";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-dodavanje-vlasnika',
  standalone: true,
  imports: [
    AdminPanelNavBarComponent,
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './dodavanje-vlasnika.component.html',
  styleUrl: './dodavanje-vlasnika.component.css'
})
export class DodavanjeVlasnikaComponent {

  constructor(private dodajVlasnikaEndpoint: DodajVlasnikaEndpoint) {
  }

  dodavanjeVlasnikaForm = new FormGroup({
    ime: new FormControl('', [Validators.required, Validators.pattern(/^([A-Z][a-z]*\s?)+$/)]),
    prezime: new FormControl('', [Validators.required, Validators.pattern(/^([A-Z][a-z]*\s?)+$/)]),
    korisnickoIme: new FormControl('', [Validators.required, Validators.minLength(5)]),
    lozinka: new FormControl('', [Validators.required, Validators.minLength(10),   Validators.pattern(/^(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{10,}$/)]),
    datumRodjenja: new FormControl('', [Validators.required, this.datumValidator]),
    email: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)]),
    brojTelefona: new FormControl('', [Validators.required, Validators.pattern(/^(\d\s*){9,}$/)]),
  });

  datumValidator(control: AbstractControl): ValidationErrors | null {
    const inputDate = control.value;
    if (!inputDate) {
      return null;
    }
    const currentDate = new Date();
    const razlikaGodina = currentDate.getFullYear() - new Date(inputDate).getFullYear();

    return razlikaGodina < 18 ? {minAge: true} : null;
  }

  dodajVlasnika() {

    const formData = {
      ime: this.dodavanjeVlasnikaForm.get('ime')?.value,
      prezime: this.dodavanjeVlasnikaForm.get('prezime')?.value,
      korisnickoIme: this.dodavanjeVlasnikaForm.get('korisnickoIme')?.value,
      lozinka: this.dodavanjeVlasnikaForm.get('lozinka')?.value,
      datumRodjenja: this.dodavanjeVlasnikaForm.get('datumRodjenja')?.value,
      email: this.dodavanjeVlasnikaForm.get('email')?.value,
      brojTelefona: this.dodavanjeVlasnikaForm.get('brojTelefona')?.value,
    };
    if (this.dodavanjeVlasnikaForm.valid) {
      this.dodajVlasnikaEndpoint.akcija(formData).subscribe(x => {
        alert("Success");
        this.dodavanjeVlasnikaForm.reset();
      })
    } else {
      alert("Error")
    }
  }
}

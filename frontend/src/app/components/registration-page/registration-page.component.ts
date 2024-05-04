import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators
} from "@angular/forms";
import {RegistrujSeEndpoint} from "../../endpoints/kupac-endpoints/registruj-se.endpoint";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-registration-page',
  standalone: true,
  imports: [
    RouterLink,
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './registration-page.component.html',
  styleUrl: './registration-page.component.css'
})
export class RegistrationPageComponent {

  constructor(private registrujSeEndpoint:RegistrujSeEndpoint) {
  }


  registrujSeForm=new FormGroup({
    ime: new FormControl('', [Validators.required, Validators.pattern(/^[A-Z][a-z]*$/)]),
    prezime: new FormControl('', [Validators.required, Validators.pattern(/^[A-Z][a-z]*$/)]),
    korisnickoIme: new FormControl('', [Validators.required, Validators.minLength(5)]),
    lozinka: new FormControl('', [Validators.required, Validators.minLength(10),   Validators.pattern(/^(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{10,}$/)]),

    datumRodjenja: new FormControl('', [Validators.required, this.datumValidator]),
    email: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)]),
    brojTelefona: new FormControl('', [Validators.required, Validators.pattern(/^\d{9,}$/)])
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
  registrujSe() {
    const formData = {
      ime: this.registrujSeForm.get('ime')?.value,
      prezime: this.registrujSeForm.get('prezime')?.value,
      korisnickoIme: this.registrujSeForm.get('korisnickoIme')?.value,
      lozinka: this.registrujSeForm.get('lozinka')?.value,
      datumRodjenja: this.registrujSeForm.get('datumRodjenja')?.value,
      email: this.registrujSeForm.get('email')?.value,
      brojTelefona: this.registrujSeForm.get('brojTelefona')?.value,
    };
    if(this.registrujSeForm.valid){
      this.registrujSeEndpoint.akcija(formData).subscribe(x=>{
        alert("Success");
        this.registrujSeForm.reset();
      })
    }
    else{
      alert("error");
    }
  }
}

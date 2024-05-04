import {Component, Input} from '@angular/core';
import {AdminPanelNavBarComponent} from "../admin-panel-nav-bar/admin-panel-nav-bar.component";
import {
  AbstractControl,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  ValidationErrors,
  Validators
} from "@angular/forms";
import {NgIf} from "@angular/common";
import {DodajRadnikaEndpoint} from "../../endpoints/vlasnik-endpoints/dodaj-radnika.endpoint";

@Component({
  selector: 'app-dodavanje-radnika',
  standalone: true,
  imports: [
    AdminPanelNavBarComponent,
    FormsModule,
    NgIf,
    ReactiveFormsModule
  ],
  templateUrl: './dodavanje-radnika.component.html',
  styleUrl: './dodavanje-radnika.component.css'
})
export class DodavanjeRadnikaComponent {
  @Input() dodajRadnika:any;

  constructor(private dodajRadnikaEndpoint:DodajRadnikaEndpoint) {
  }

  dodajRadnikaForm=new FormGroup({
    ime: new FormControl('', [Validators.required, Validators.pattern(/^[A-Z][a-z]*$/)]),
    prezime: new FormControl('', [Validators.required, Validators.pattern(/^[A-Z][a-z]*$/)]),
    korisnickoIme: new FormControl('', [Validators.required, Validators.minLength(5)]),
    lozinka: new FormControl('', [Validators.required, Validators.minLength(10),   Validators.pattern(/^(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{10,}$/)]),
    datumRodjenja: new FormControl('', [Validators.required, this.datumRodjenjaValidator]),
    email: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)]),
    brojTelefona: new FormControl('', [Validators.required, Validators.pattern(/^(\d\s*){9,}$/)]),
    datumZaposlenja:new FormControl('',[Validators.required, this.datumZaposlenjaValidator]),
    restoranID:new FormControl('')
  });
  datumRodjenjaValidator(control: AbstractControl): ValidationErrors | null {
    const inputDate = control.value;
    if (!inputDate) {
      return null;
    }
    const currentDate = new Date();
    const razlikaGodina = currentDate.getFullYear() - new Date(inputDate).getFullYear();

    return razlikaGodina < 18 ? {minAge: true} : null;
  }
  datumZaposlenjaValidator(control: AbstractControl): ValidationErrors | null {
    const inputDate = control.value;
    if (!inputDate) {
      return null;
    }

    const currentDate = new Date();
    const inputDateTime = new Date(inputDate);

    return inputDateTime > currentDate ? { futureDate: true } : null;
  }
  zatvoriDodavanjeRadnika() {
    this.dodajRadnika=null;
  }

  dodavanjeRadnika() {
    const formData={
      ime: this.dodajRadnikaForm.get('ime')?.value,
      prezime: this.dodajRadnikaForm.get('prezime')?.value,
      korisnickoIme: this.dodajRadnikaForm.get('korisnickoIme')?.value,
      lozinka: this.dodajRadnikaForm.get('lozinka')?.value,
      datumRodjenja: this.dodajRadnikaForm.get('datumRodjenja')?.value,
      email: this.dodajRadnikaForm.get('email')?.value,
      brojTelefona: this.dodajRadnikaForm.get('brojTelefona')?.value,
      datumZaposlenja:this.dodajRadnikaForm.get('datumZaposlenja')?.value,
      restoranID:this.dodajRadnika.id
    };
    if (this.dodajRadnikaForm.valid) {
      this.dodajRadnikaEndpoint.akcija(formData).subscribe(x => {
        alert("Success");
        this.dodajRadnikaForm.reset();
      })
    } else {
      alert("Error")
    }
  }
}

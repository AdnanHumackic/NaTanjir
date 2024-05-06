import {Injectable} from "@angular/core";

@Injectable({providedIn:'root'})

export class ImageService{


  vrijednost:any;
  generatePreview(divName:string, formName:any){
    // @ts-ignore
    const file=document.getElementById(divName).files[0];

    if (file && formName) {
      var reader = new FileReader();
      reader.onload = () => {
        this.vrijednost = reader.result?.toString();
        return this.vrijednost;
      };
      reader.readAsDataURL(file);
    }
  }

}

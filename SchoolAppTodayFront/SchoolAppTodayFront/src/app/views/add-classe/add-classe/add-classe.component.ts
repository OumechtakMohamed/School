import { Component, OnInit , Input} from '@angular/core';
import { Classe } from 'src/app/models/classe.model';
import { Location } from '@angular/common';
import { ClasseService } from 'src/app/services/classes/classe.service';
import { forEach } from '@angular/router/src/utils/collection';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-classe',
  templateUrl: './add-classe.component.html',
  styleUrls: ['./add-classe.component.css']
})
export class AddClasseComponent implements OnInit {
  title ="Add a New Classe";
  classes : Classe[];
  classe : Classe = {Code:"",Label:""};
  existence: boolean;
  constructor(private toastr : ToastrService,private location : Location, private classeService: ClasseService){}

  ngOnInit() {
    this.existence = false;
    this.classeService.getAllClasses()
    .subscribe(
      (data : any) => 
       { this.classes = data;
        console.log("here the fetched classes: "+data);
      },
        (error : any) => {
          console.log("error on getting data from classes")
        }
    );
  }

  goBack(): void {
    this.location.back();
  }

  verifyExistence(c: String): boolean{
    this.classes.forEach(entry => {
     if(entry.Code == c) {this.existence = true;}
    });
    return this.existence;
  }
  save(c: Classe): void {
    if(this.verifyExistence(c.Code)){
      this.toastr.error("Already existed");
      this.existence = false;
    }
    else{
      this.classeService.addClasse(c)
      .subscribe(() => this.goBack());
    }
    
  }

}

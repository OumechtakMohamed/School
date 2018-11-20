import { Component, OnInit } from '@angular/core';
import { ClasseService } from 'src/app/services/classes/classe.service';
import { Classe } from 'src/app/models/classe.model';
import { Router } from '@angular/router';


@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css']
})
export class ClassesComponent implements OnInit {

  title : any;
  classes : any[];
  classValue:any;
  showVar: boolean = true;

  constructor(private classeService : ClasseService, private router : Router) { }

  ngOnInit() {
    this.title = "Classes";
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

  delete(cla: Classe): void {
    this.classes = this.classes.filter(h => h !== cla);
    this.classeService.deleteClasse(cla).subscribe();
  }

}

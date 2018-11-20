import { Component, OnInit, Input } from '@angular/core';
import { Classe } from 'src/app/models/classe.model';
import { ClasseService } from 'src/app/services/classes/classe.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-classe-detail',
  templateUrl: './classe-detail.component.html',
  styleUrls: ['./classe-detail.component.css']
})
export class ClasseDetailComponent implements OnInit {
  title = "Edit Classe";
  classe : Classe;
  constructor(private location : Location,private route: ActivatedRoute, private classeService: ClasseService) { }

  
  ngOnInit() {
    this.getClasse();
  }

  getClasse(): void {
    const code = this.route.snapshot.paramMap.get('code');
    this.classeService.getClasse(code)
      .subscribe(data => {
        this.classe = data;
        console.log('data', data);
     })
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.classeService.updateClasse(this.classe)
      .subscribe(() => this.goBack());
  }

}

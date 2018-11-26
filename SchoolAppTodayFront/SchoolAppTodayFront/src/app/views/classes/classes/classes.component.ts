import { Component, OnInit } from '@angular/core';
import { ClasseService } from 'src/app/services/classes/classe.service';
import { Classe } from 'src/app/models/classe.model';
import {
  Router
} from '@angular/router'
import { NgxSmartModalService } from 'ngx-smart-modal';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { OrderPipe } from 'ngx-order-pipe';
import { SearchPipe } from 'src/app/pipes/search.pipe';
import { TeacherService } from 'src/app/services/teachers/teacher.service';
import { state } from '@angular/animations';

@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css']
})
export class ClassesComponent implements OnInit {

  title : any;
  classes : any[];
  classeFilter: any = { Code: '',Label: '' };
  classValue:any;
  chosen : Classe;
  showVar: boolean = true;
  timer: any;
  loading : boolean;
  sortedClasses: any[];
  teachersOfClasse: any[];
  chosedClassForPopup: string;
  teachers: any[];
  order: string = 'code';
  order1: string = 'FullName';
  reverse: boolean = false;
  reverse1: boolean = false;
  query:string = '';
  tab1 : boolean = true;
  tab2 : boolean =false;
  constructor(private teacherService : TeacherService,private orderPipe: OrderPipe, private spinnerService: Ng4LoadingSpinnerService,public ngxSmartModalService: NgxSmartModalService,private classeService : ClasseService, private router : Router) { 
    this.sortedClasses = orderPipe.transform(this.classes, 'code');
  }

  ngOnInit() {
    
    this.title = "Classes:";
    this.loading = true;
    this.showLoader();
    this.classeService.getAllClasses()
    .subscribe(
      (data : any) => 
       { 
         this.classes = data;
         this.hideLoader();
        console.log("here the fetched classes: "+data);
      },
        (error : any) => {
          console.log("error on getting data from classes");
        }
    );
  }

  showLoader(){
    this.loading = true;
    this.spinnerService.show();
  }

  hideLoader(){
    this.loading = false;
    this.spinnerService.hide();
  }

  showDelete(cla: Classe): void {
    this.chosen = cla;
    this.ngxSmartModalService.getModal('myModal').open();
  }

  loadAllTeachers(){
    this.teacherService.getAllTeachers().subscribe(
      (data : any) => 
       { this.teachers = data;
        console.log("here the fetched teachers data: "+data);
      },
        (error : any) => {
          console.log("error on getting data from teachers data")
        }
    );
  }

  loadTeachersOfClasse(code : string){
    this.classeService.getTeachersOfClasse(code).subscribe(
      (data : any) => 
       { this.teachersOfClasse = data;
        console.log("here the fetched teachers data: "+data);
      },
        (error : any) => {
          console.log("error on getting data from teachers data")
        }
    );
  }


  loadCorresondingTeachers(code : string){
    this.loadTeachersOfClasse(code);
    this.loadAllTeachers();
  }

  showTeachers(cla: Classe): void {
    this.ngxSmartModalService.getModal('TeachersModal').open();
    this.chosedClassForPopup = cla.Code;
    this.loadCorresondingTeachers(cla.Code);
  }

  delete(cla: Classe): void {
    this.classes = this.classes.filter(h => h !== cla);
    this.classeService.deleteClasse(cla).subscribe();
    this.ngxSmartModalService.getModal('myModal').close();
  }

  deleteteacherFromClasse(code : string,id : number){
    this.classeService.deleteTeacherFromClasse(code,id).subscribe(
      (data : any) => 
      { 
       console.log("Sucess");
       this.loadCorresondingTeachers(this.chosedClassForPopup);
     },
       (error : any) => {
         console.log("Error")
       }
    );
  }

  addteacherToClasse(code : string,id : number){
    this.classeService.addTeacherToClasse(code,id).subscribe(
      (data : any) => 
      { 
       console.log("Sucess");
       this.loadCorresondingTeachers(this.chosedClassForPopup);
     },
       (error : any) => {
         console.log("Error")
       }
    );
  }

  verifyState(t : any): string{
    let state = "ToAdd";
        this.teachersOfClasse.forEach( (element) => {
      if(t.Id == element.Id) state = "ToDelete";
      else if(t.Id != element.Id && t.Code == element.Subject_Code) state = "Blocked";
  });
  return state;
  }

  setOrder(value: string) {
    if (this.order === value) {
      this.reverse = !this.reverse;
    }

    this.order = value;
  }

  setOrder1(value: string) {
    if (this.order1 === value) {
      this.reverse1 = !this.reverse1;
    }

    this.order1 = value;
  }
}

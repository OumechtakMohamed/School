import { Component, OnInit } from '@angular/core';
import { SubjectService } from 'src/app/services/subjects/subject.service';
import { Subject} from 'src/app/models/subject.model';
import {
  Router
} from '@angular/router'
import { NgxSmartModalService } from 'ngx-smart-modal';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { OrderPipe } from 'ngx-order-pipe';
import { SearchPipe } from 'src/app/pipes/search.pipe';


@Component({
  selector: 'app-subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.css']
})
export class SubjectsComponent implements OnInit {

  title : any;
  subjects : any[];
  
  subjectFilter: any = { Code: '',Label: '' };
  subjectValue:any;
  chosen : Subject;
  showVar: boolean = true;
  timer: any;
  sortedSubjects : any[];
  order: string = 'code';
  reverse: boolean = false;
  query:string = '';

  constructor(private orderPipe: OrderPipe,private spinnerService: Ng4LoadingSpinnerService,public ngxSmartModalService: NgxSmartModalService,private subjectService : SubjectService, private router : Router) { 
    this.sortedSubjects = orderPipe.transform(this.subjects, 'code');
  }

  ngOnInit() {
    
    this.title = "Subjects:";
    this.subjectService.getAllSubjects()
    .subscribe(
      (data : any) => 
       {  this.spinnerService.hide();
         this.subjects = data;
        console.log("here the fetched subjects: "+data);
      },
        (error : any) => {
          console.log("error on getting data from subjects");
        }
    );
  }


  showDelete(sub: Subject): void {
    this.chosen = sub;
    this.ngxSmartModalService.getModal('myModal').open();
  }

  delete(cla: Subject): void {
    this.subjects = this.subjects.filter(h => h !== cla);
    this.subjectService.deleteSubject(cla).subscribe();
    this.ngxSmartModalService.getModal('myModal').close();
  }

  setOrder(value: string) {
    if (this.order === value) {
      this.reverse = !this.reverse;
    }

    this.order = value;
  }
}

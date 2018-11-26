import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teachers/teacher.service';
import { Teacher} from 'src/app/models/teacher.model';
import {
  Router
} from '@angular/router'
import { NgxSmartModalService } from 'ngx-smart-modal';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { OrderPipe } from 'ngx-order-pipe';
import { SearchPipe } from 'src/app/pipes/search.pipe';

@Component({
  selector: 'app-teacher',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent implements OnInit {

  title : any;
  teachers : any[];
  teacherFilter: any = { FullName: '',FirstName: '' , LastName : ''};
  teacherValue:any;
  chosen : Teacher;
  showVar: boolean = true;
  timer: any;
  sortedTeachers : any[];
  order: string = 'FirstName';
  reverse: boolean = false;
  query:string = '';

  constructor(private orderPipe: OrderPipe,private spinnerService: Ng4LoadingSpinnerService,public ngxSmartModalService: NgxSmartModalService,private teacherService : TeacherService, private router : Router) { 
    this.sortedTeachers = orderPipe.transform(this.teachers, 'FirstName');
  }

  ngOnInit() {
    
    this.title = "Teachers:";
    this.teacherService.getAllTeachers()
    .subscribe(
      (data : any) => 
       {  this.spinnerService.hide();
         this.teachers = data;
        console.log("here the fetched teachers: "+data);
      },
        (error : any) => {
          console.log("error on getting data from teachers");
        }
    );
  }

  showDelete(sub: Teacher): void {
    this.chosen = sub;
    this.ngxSmartModalService.getModal('myModal').open();
  }

  delete(cla: Teacher): void {
    this.teachers = this.teachers.filter(h => h !== cla);
    this.teacherService.deleteTeacher(cla).subscribe();
    this.ngxSmartModalService.getModal('myModal').close();
  }

  
  setOrder(value: string) {
    if (this.order === value) {
      this.reverse = !this.reverse;
    }

    this.order = value;
  }
}

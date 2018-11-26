import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/students/student.service';
import { Student} from 'src/app/models/student.model';
import {
  Router
} from '@angular/router'
import { NgxSmartModalService } from 'ngx-smart-modal';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { OrderPipe } from 'ngx-order-pipe';
import { SearchPipe } from 'src/app/pipes/search.pipe';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  title : any;
  students : any[];
  studentFilter: any = { FullName: '',FirstName: '' , LastName : ''};
  studentValue:any;
  chosen : Student;
  showVar: boolean = true;
  timer: any;
  sortedStudents : any[];
  order: string = 'FirstName';
  reverse: boolean = false;
  query:string = '';

  constructor(private orderPipe: OrderPipe,private spinnerService: Ng4LoadingSpinnerService,public ngxSmartModalService: NgxSmartModalService,private studentService : StudentService, private router : Router) { 
    this.sortedStudents = orderPipe.transform(this.students, 'FirstName');
  }

  ngOnInit() {
    
    this.title = "Students:";
    this.studentService.getAllStudents()
    .subscribe(
      (data : any) => 
       {  this.spinnerService.hide();
         this.students = data;
        console.log("here the fetched students: "+data);
      },
        (error : any) => {
          console.log("error on getting data from students");
        }
    );
  }

  showDelete(sub: Student): void {
    this.chosen = sub;
    this.ngxSmartModalService.getModal('myModal').open();
  }

  delete(cla: Student): void {
    this.students = this.students.filter(h => h !== cla);
    this.studentService.deleteStudent(cla).subscribe();
    this.ngxSmartModalService.getModal('myModal').close();
  }

  
  setOrder(value: string) {
    if (this.order === value) {
      this.reverse = !this.reverse;
    }

    this.order = value;
  }
}

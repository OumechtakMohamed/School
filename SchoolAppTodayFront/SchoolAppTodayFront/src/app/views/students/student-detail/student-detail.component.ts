import { Component, OnInit, Input } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { StudentService } from 'src/app/services/students/student.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ClasseService } from 'src/app/services/classes/classe.service';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styleUrls: ['./student-detail.component.css']
})
export class StudentDetailComponent implements OnInit {
  title = "Edit Student:";
  student : Student;
  classes : any[];
  classeValue : any;
  constructor(private classeService : ClasseService,private location : Location,private route: ActivatedRoute, private studentService: StudentService) { }

  
  ngOnInit() {
    this.getStudent();
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

  getStudent(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.studentService.getStudent(id)
      .subscribe(data => {
        this.student = data;  
        this.classeValue = this.student.Code;
        console.log('data', data);
     })
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.studentService.updateStudent(this.student)
    .subscribe(() => this.goBack());
  }

}

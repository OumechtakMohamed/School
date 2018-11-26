import { Component, OnInit, Input } from '@angular/core';
import { Teacher } from 'src/app/models/teacher.model';
import { TeacherService } from 'src/app/services/teachers/teacher.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { SubjectService } from 'src/app/services/subjects/subject.service';

@Component({
  selector: 'app-teacher-detail',
  templateUrl: './teacher-detail.component.html',
  styleUrls: ['./teacher-detail.component.css']
})
export class TeacherDetailComponent implements OnInit {
  title = "Edit Teacher:";
  teacher : Teacher;
  subjects : any[];
  subjectValue : any;
  constructor(private subjectService : SubjectService,private location : Location,private route: ActivatedRoute, private teacherService: TeacherService) { }

  
  ngOnInit() {
    this.getTeacher();
    this.subjectService.getAllSubjects()
    .subscribe(
      (data : any) => 
       { this.subjects = data;
        console.log("here the fetched subjects: "+data);
      },
        (error : any) => {
          console.log("error on getting data from subjects")
        }
    );
  }

  getTeacher(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.teacherService.getTeacher(id)
      .subscribe(data => {
        this.teacher = data;  
        this.subjectValue = this.teacher.Code;
        console.log('data', data);
     })
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.teacherService.updateTeacher(this.teacher)
    .subscribe(() => this.goBack());
  }

}

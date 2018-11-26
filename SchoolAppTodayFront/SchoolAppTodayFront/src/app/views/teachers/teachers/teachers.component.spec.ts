import { Component, OnInit, Input } from '@angular/core';
import { Teacher } from 'src/app/models/teacher.model';
import { TeacherService } from 'src/app/services/teachers/teacher.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-teacher-detail',
  templateUrl: './teacher-detail.component.html',
  styleUrls: ['./teacher-detail.component.css']
})
export class TeacherDetailComponent implements OnInit {
  title = "Edit Teacher:";
  loading : boolean;
  teacher : Teacher;
  constructor( private location : Location,private route: ActivatedRoute, private teacherService: TeacherService) { }

  
  ngOnInit() {
    this.loading = true;
    this.getTeacher();
  }

  getTeacher(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.teacherService.getTeacher(id)
      .subscribe(data => {
        this.teacher = data;
        console.log('data', data);
     })
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
      
  }

}

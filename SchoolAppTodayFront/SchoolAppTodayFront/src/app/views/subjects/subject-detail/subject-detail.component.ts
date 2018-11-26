import { Component, OnInit, Input } from '@angular/core';
import { Subject } from 'src/app/models/subject.model';
import { SubjectService } from 'src/app/services/subjects/subject.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-subject-detail',
  templateUrl: './subject-detail.component.html',
  styleUrls: ['./subject-detail.component.css']
})
export class SubjectDetailComponent implements OnInit {
  title = "Edit Subject:";
  subject : Subject;
  constructor(private location : Location,private route: ActivatedRoute, private subjectService: SubjectService) { }

  
  ngOnInit() {
    this.getSubject();
  }

  getSubject(): void {
    const code = this.route.snapshot.paramMap.get('code');
    this.subjectService.getSubject(code)
      .subscribe(data => {
        this.subject = data;
        console.log('data', data);
     })
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.subjectService.updateSubject(this.subject)
      .subscribe(() => this.goBack());
  }

}

import { Component, OnInit , Input} from '@angular/core';
import { Subject } from 'src/app/models/subject.model';
import { Location } from '@angular/common';
import { SubjectService } from 'src/app/services/subjects/subject.service';
import { forEach } from '@angular/router/src/utils/collection';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-subject',
  templateUrl: './add-subject.component.html',
  styleUrls: ['./add-subject.component.css']
})
export class AddSubjectComponent implements OnInit {
  title ="Add a New Subject:";
  subjects : Subject[];
  subject : Subject = {Code:"",Label:""};
  existence: boolean;
  constructor(private toastr : ToastrService,private location : Location, private subjectService: SubjectService){}

  ngOnInit() {
    this.existence = false;
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

  goBack(): void {
    this.location.back();
  }

  verifyExistence(c: String): boolean{
    this.subjects.forEach(entry => {
     if(entry.Code == c) {this.existence = true;}
    });
    return this.existence;
  }
  save(c: Subject): void {
    if(this.verifyExistence(c.Code)){
      this.toastr.error("("+c.Code+") Already existed");
      this.existence = false;
    }
    else{
      this.subjectService.addSubject(c)
      .subscribe(() => this.goBack());
    }
    
  }

}

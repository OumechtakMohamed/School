import { Component, OnInit } from '@angular/core';
import { User } from '../../shared/user.model';
import {NgForm} from '@angular/forms';
import {UserService} from '../../shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { ClasseService } from 'src/app/services/classes/classe.service';
import { SubjectService } from 'src/app/services/subjects/subject.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user : User;
  roles : any[];
  classes : any[];
  radioSelected:any;
  classValue:any;
  subjects : any[];
  subjectValue : any;

  constructor(private userService : UserService, private toastr: ToastrService, private classeService : ClasseService, private subjectService : SubjectService){ }

  ngOnInit() {
    this.resetForm();
    this.userService.getAllRoles().subscribe(
      (data : any) => 
       { this.roles = data;
        console.log("here the fetched roles: "+data);
      },
        (error : any) => {
          console.log("error on getting data from roles")
        }
    );
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

  resetForm(form? : NgForm){
     if(form != null)
     form.reset();
     this.user = {
     	UserName : '',
     	Password : '',
     	Email : '',
     	FirstName : '',
      LastName : '',
     }
  }

  handleChange(radioSelected){
    if(radioSelected == '3'){
      this.classValue = 'STE1';
      this.subjectValue = null;
    }
    if(radioSelected == '2'){
      this.classValue = null;
      this.subjectValue = 'M';
    }
    if(radioSelected == '1'){
      this.classValue = null;
      this.subjectValue = null;
    }
  }

  OnSubmit(form : NgForm){
   var x = this.roles.filter(x => x.Id == this.radioSelected).map(y => y.Name);
   var cls = this.classes.filter(x => x.Code == this.classValue).map(y => y.Code);
   var subj = this.subjects.filter(x => x.Code == this.subjectValue).map(y => y.Code);
   this.userService.registerUser(form.value,x.toString(), cls.toString(),subj.toString())
   .subscribe((data:any) => {
     if(data.Succeeded == true)
     	{this.resetForm(form);
        this.toastr.success("user registration successful");
    }
    else
    	this.toastr.error(data.Errors[0]);
   });
  }
}

import { Component, OnInit } from '@angular/core';
import { User } from '../../shared/user.model';
import {NgForm} from '@angular/forms';
import {UserService} from '../../shared/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user : User;
  roles : any[];
  radioSelected:any;

  constructor(private userService : UserService, private toastr: ToastrService){ }

  ngOnInit() {
    this.resetForm();
    this.userService.getAllRoles().subscribe(
      (data : any) => 
      /*  {data.array.forEach(obj => 
          obj.selected = false
        );*/
       { this.roles = data;
        console.log("here the fetched data: "+data);
      },
        (error : any) => {
          console.log("error on getting data from roles")
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
     	LastName : ''
     }
     if(this.roles){
       this.roles.map(x => x.selected = false);
     }
  }

  OnSubmit(form : NgForm){
   var x = this.roles.filter(x => x.Id == this.radioSelected).map(y => y.Name);
   this.userService.registerUser(form.value,x.toString())
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

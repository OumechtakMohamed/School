import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/users/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  infos : any;
  isLoginError : boolean = false;
  constructor(private userService : UserService, private router : Router) { }

  ngOnInit() {
    localStorage.removeItem('userToken');
  }

  OnSubmit(userName, password){
      this.userService.userAuthentication(userName,password).subscribe((data : any)=>{
        localStorage.setItem('userToken', data.access_token);
        localStorage.setItem('userRoles', data.role);
        this.infos = data;
        switch (this.infos.role[0][0]) 
          { 
          case "Admin": 
          this.router.navigate(['/classes']);
          break; 
          case "Student": 
          this.router.navigate(['/mystudent']);
          break; 
          case "Teacher":
          this.router.navigate(['/myteacher']); 
          break; 
          default:
          this.router.navigate(['/profile']); 
          break;
          }
      },
      (err : HttpErrorResponse) => {
        this.isLoginError = true;
      });
  }

}

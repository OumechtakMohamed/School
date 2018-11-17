import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/users/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userClaims : any;
  today: number = Date.now();

  constructor(private router : Router, private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaims().subscribe((data : any) => {
      this.userClaims = data;
    })

    if(this.userService.roleMatch(['Author']))
    {
      //
    }
  }

  Logout(){
    localStorage.removeItem('userToken');
    this.router.navigate(['/login']);
  }
}

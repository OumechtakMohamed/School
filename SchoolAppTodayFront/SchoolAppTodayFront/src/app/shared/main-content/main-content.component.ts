import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/users/user.service';

@Component({
  selector: 'app-main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.css']
})
export class MainContentComponent implements OnInit {
  userClaims : any;
  today: number = Date.now();

  constructor(private router : Router, private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaims().subscribe((data : any) => {
      this.userClaims = data;
    })

    if(this.userService.roleMatch(['Admin']))
    {
      //
    }
  }

  Logout(){
    localStorage.removeItem('userToken');
    this.router.navigate(['/login']);
  }
}

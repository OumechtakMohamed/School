import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/services/users/user.service';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css'],
})
export class MainNavComponent implements OnInit{
  userClaims : any;
  today: number = Date.now();

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private router : Router,private userService: UserService,private breakpointObserver: BreakpointObserver) {}

  
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

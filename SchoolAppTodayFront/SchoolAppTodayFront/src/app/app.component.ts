import { Component } from '@angular/core';
import { Spinkit } from 'ng-http-loader';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  public spinkit = Spinkit;
  title = 'SchoolAppTodayFront';
  template: string =`<img class="custom-spinner-template" src="https://thumbs.gfycat.com/WelldocumentedRevolvingBass-size_restricted.gif">`;
}

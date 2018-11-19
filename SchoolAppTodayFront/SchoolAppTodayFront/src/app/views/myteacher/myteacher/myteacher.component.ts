import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teachers/teacher.service';

@Component({
  selector: 'app-myteacher',
  templateUrl: './myteacher.component.html',
  styleUrls: ['./myteacher.component.css']
})
export class MyteacherComponent implements OnInit {

  title = 'My Data:';
  myData : any[];
  constructor(private teacherService : TeacherService) { }

  ngOnInit() {
    this.teacherService.getMyTeacherData().subscribe(
      (data : any) => 
       { this.myData = data;
        console.log("here the fetched teacher data: "+data);
      },
        (error : any) => {
          console.log("error on getting data from teacher data")
        }
    );
  }

}

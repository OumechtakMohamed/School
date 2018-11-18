import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/students/student.service';

@Component({
  selector: 'app-mystudent',
  templateUrl: './mystudent.component.html',
  styleUrls: ['./mystudent.component.css']
})
export class MystudentComponent implements OnInit {

  title = 'My Data:';
  myData : any[];
  constructor(private studentService : StudentService) { }

  ngOnInit() {
    this.studentService.getMyStudentData().subscribe(
      (data : any) => 
       { this.myData = data;
        console.log("here the fetched student data: "+data);
      },
        (error : any) => {
          console.log("error on getting data from student data")
        }
    );
  }

}

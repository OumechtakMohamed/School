import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Response} from '@angular/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import { HttpModule } from '@angular/http';
import { environment } from 'src/app/config/environment';
import { Student } from 'src/app/models/student.model';

const httpOptions = {
  headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})
};


@Injectable({
  providedIn: 'root'
})
export class StudentService {
  readonly rootUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }
  getMyStudentData(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/StudentData', httpOptions);
  }

  getAllStudents(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/students', httpOptions);
  }

  deleteStudent (student: Student | string): Observable<Student> {
    const id = typeof student === 'string' ? student : student.Id;
    const url = `${this.rootUrl+'/api/student'}/${id}`;

    return this.http.delete<Student>(url, httpOptions);
  }

  updateStudent (c: Student) {
    const url = `${this.rootUrl+'/api/student/update'}`;
    return this.http.put(url, c, httpOptions);
  }

  getStudent(id: number): Observable<Student>{
    const url = `${this.rootUrl+'/api/student'}/${id}`;
    return this.http.get<Student>(url, httpOptions);
  }
}

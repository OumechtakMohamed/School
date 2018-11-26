import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Response} from '@angular/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import { HttpModule } from '@angular/http';
import { environment } from 'src/app/config/environment';
import { Teacher } from 'src/app/models/teacher.model';

const httpOptions = {
  headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})
};


@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  readonly rootUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }
  getMyTeacherData(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/TeacherData', {headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})});
  }

  getAllTeachers(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/teachers', httpOptions);
  }

  getTeacher(id: number): Observable<Teacher>{
    const url = `${this.rootUrl+'/api/teacher'}/${id}`;
    return this.http.get<Teacher>(url, httpOptions);
  }

  deleteTeacher (teacher: Teacher | string): Observable<Teacher> {
    const id = typeof teacher === 'string' ? teacher : teacher.Id;
    const url = `${this.rootUrl+'/api/teacher'}/${id}`;

    return this.http.delete<Teacher>(url, httpOptions);
  }
  updateTeacher (c: Teacher) {
    const url = `${this.rootUrl+'/api/teacher/update'}`;
    return this.http.put(url, c, httpOptions);
  }
}

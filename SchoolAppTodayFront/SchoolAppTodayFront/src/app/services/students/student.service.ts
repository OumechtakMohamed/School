import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Response} from '@angular/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import { HttpModule } from '@angular/http';
import { environment } from 'src/app/config/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  readonly rootUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }
  getMyStudentData(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/StudentData', {headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})});
  }
}

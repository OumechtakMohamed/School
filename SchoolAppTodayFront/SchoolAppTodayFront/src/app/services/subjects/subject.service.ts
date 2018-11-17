import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  readonly rootUrl = 'http://localhost:47475';
  constructor(private http: HttpClient) { }

  getAllSubjects(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/subjects', {headers: reqHeader});
  }
}

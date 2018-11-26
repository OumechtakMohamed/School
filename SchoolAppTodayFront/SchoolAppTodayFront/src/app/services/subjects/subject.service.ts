import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from 'src/app/config/environment';
import { Subject } from 'src/app/models/subject.model';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})
};

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  readonly rootUrl = environment.baseUrl;
  messages: string[] = [];
  constructor(private http: HttpClient) { }

  getAllSubjects(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/subjects', httpOptions);
  }

  
  getSubject(code: string): Observable<Subject>{
    const url = `${this.rootUrl+'/api/subject'}/${code}`;
    return this.http.get<Subject>(url, httpOptions);
  }

  updateSubject (c: Subject): Observable<any> {
    const url = `${this.rootUrl+'/api/subject/update'}`;
    return this.http.put(url, c, httpOptions);
  }

  addSubject (c : Subject): Observable<any> {
    const url = `${this.rootUrl+'/api/subject/create'}`;
    return this.http.post(url, c, httpOptions);
  }

  deleteSubject (subject: Subject | string): Observable<Subject> {
    const code = typeof subject === 'string' ? subject : subject.Code;
    const url = `${this.rootUrl+'/api/subject'}/${code}`;

    return this.http.delete<Subject>(url, httpOptions);
  }
}

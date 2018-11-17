import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from 'src/app/config/environment';

@Injectable({
  providedIn: 'root'
})
export class ClasseService {

  readonly rootUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  getAllClasses(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/classes', {headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})});
  }
}

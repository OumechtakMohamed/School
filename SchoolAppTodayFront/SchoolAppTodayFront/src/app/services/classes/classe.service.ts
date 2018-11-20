import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from 'src/app/config/environment';
import { Classe } from 'src/app/models/classe.model';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})
};


@Injectable({
  providedIn: 'root'
})
export class ClasseService {

  readonly rootUrl = environment.baseUrl;
  messages: string[] = [];
  constructor(private http: HttpClient) { }

  getAllClasses(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl+ '/api/classes', httpOptions);
  }

  getClasse(code: string): Observable<Classe>{
    const url = `${this.rootUrl+'/api/classe'}/${code}`;
    return this.http.get<Classe>(url, httpOptions);
  }

  updateClasse (c: Classe): Observable<any> {
    const url = `${this.rootUrl+'/api/classe/update'}`;
    return this.http.put(url, c, httpOptions);
  }

  addClasse (c : Classe): Observable<any> {
    const url = `${this.rootUrl+'/api/classe/create'}`;
    return this.http.post(url, c, httpOptions);
  }

  deleteClasse (classe: Classe | string): Observable<Classe> {
    const code = typeof classe === 'string' ? classe : classe.Code;
    const url = `${this.rootUrl+'/api/classe'}/${code}`;

    return this.http.delete<Classe>(url, httpOptions);
  }
}

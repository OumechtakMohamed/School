import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Response} from '@angular/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {User} from './user.model';

@Injectable()

export class UserService {
  readonly rootUrl = 'http://localhost:47475';
  constructor(private http: HttpClient) { }

  registerUser(user : User){
  	const body : User = {
  		UserName : user.UserName,
  		Password : user.Password,
  		Email : user.Email,
  		FirstName : user.FirstName,
  		LastName : user.LastName
  	}
  	return this.http.post(this.rootUrl + '/api/User/Register', body);
  }

  userAuthentication(userName, password){
	  var data = "username="+userName+"&password="+password+"&grant_type=password";
	  var reqHeader = new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded'});
	  return this.http.post(this.rootUrl+'/token',data, {headers : reqHeader});
	}

   getUserClaims(){
	   return this.http.get(this.rootUrl+'/api/GetUserClaims', {headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})});
   }
}

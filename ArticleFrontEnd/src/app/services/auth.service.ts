import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from "@auth0/angular-jwt";
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  httpOptions ={
    headers: new HttpHeaders({
      'Content-Type':'application/json',
      Authorization: `Bearer ${this.tokens}`
    })
  }

baseUrI='https://localhost:7297/api/auth';
//token:any;
  constructor(private HttpClient:HttpClient) { }

  login(credentials:any){

    return this.HttpClient.post(this.baseUrI+'/login',
    JSON.stringify(credentials),this.httpOptions).pipe(
      map(response =>
      { 
        let result :any =response;
        if(result && result.token){
          localStorage.setItem('token',result.token);
          return true;
        }
        return false;      
      })
    );
  }

  signup(credentials:any){
    return this.HttpClient.post(this.baseUrI +'/register',
    JSON.stringify(credentials),this.httpOptions).pipe(
      map(response =>{
        let result :any = response;
        if(result)
           return true;
        
        return false;
      })
    );
  }

  logout(){
    localStorage.removeItem('token');
  }

  isLoggedIn(){
    let token = localStorage.getItem('token');

    if(!token)
      return false
    let jwtHelper = new JwtHelperService();
    let isExpired = jwtHelper.isTokenExpired(token!);
    return !isExpired;  
  }

  get tokens(){
    let token = localStorage.getItem('token');
    return token;
  }

  get currentUser(){
    let token = localStorage.getItem('token');
    
    return new JwtHelperService().decodeToken(token!);
  }

  GetUserRole() {
    const token = this.tokens;
    if (!token) {
      return;
    }
    let jwtHelper = new JwtHelperService();

    let tokenData =jwtHelper.decodeToken(token);
    let role =
        tokenData[
          "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        ];
    return role;
}

// IsAdmin(){
//   let admin = this.GetUserRole();
//   if(admin ==='Admin')
//   return true;
//   else
//   return false;
// }

}

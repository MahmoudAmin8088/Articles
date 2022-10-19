import { AppError } from './../common/app-error';
import { NotFoundError } from './../common/not-found-error';
import { BadInput } from './../common/bad-input';
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {


  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
       Authorization: `Bearer ${this.authService.tokens}`
    })
  }

  constructor(@Inject(String) private baseURL:string,private authService:AuthService,
  private HttpClient:HttpClient) { }

  GetArticleComments(articleId:string):Observable<any[]>{
    return this.HttpClient.get<any[]>(this.baseURL +'/GetArticleComments/'+ articleId,this.httpOptions);
  }
  GetAll():Observable<any[]>{
    return this.HttpClient.get<any[]>(this.baseURL,this.httpOptions)
  }
  Get(id:string):Observable<any>{
    return this.HttpClient.get<any>(this.baseURL+'/'+id);
  }

  Create(resource:any):Observable<any>{
    debugger
    return this.HttpClient.post(this.baseURL +'/Create',JSON.stringify(resource),this.httpOptions).pipe(
      catchError(this.handleError)
      
    );
  }
  Update(resource:any):Observable<any>{
    return this.HttpClient.put<any>(this.baseURL+'/Update',JSON.stringify(resource),this.httpOptions).pipe(
      catchError(this.handleError)

    );
  }

  Delete(id:string):Observable<any>{
    return this.HttpClient.delete<any>(this.baseURL+'/'+id,this.httpOptions).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error:Response){
    if(error.status=== 400)
      return throwError(new BadInput(error.json()));
    if(error.status === 404)
      return throwError(new NotFoundError());
    return throwError(new AppError(error.json()));
  }
}

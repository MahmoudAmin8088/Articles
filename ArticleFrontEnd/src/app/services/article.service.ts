import { DataService } from './data.service';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ArticleService extends DataService {

  constructor(HttpClient:HttpClient ,Auth:AuthService) {
    super('https://localhost:7297/api/Article',Auth,HttpClient);
  }
}

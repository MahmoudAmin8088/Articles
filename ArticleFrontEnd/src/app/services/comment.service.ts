import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentService extends DataService {

  
  constructor(HttpClient:HttpClient,Auth:AuthService) {
    super('https://localhost:7297/api/Comment',Auth,HttpClient);
  }

  
}

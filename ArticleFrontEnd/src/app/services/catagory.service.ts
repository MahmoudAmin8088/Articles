import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CatagoryService extends DataService {

  
  constructor(HttpClient:HttpClient,Auth:AuthService) {
    super('https://localhost:7297/api/Catigory',Auth,HttpClient);
  }
}

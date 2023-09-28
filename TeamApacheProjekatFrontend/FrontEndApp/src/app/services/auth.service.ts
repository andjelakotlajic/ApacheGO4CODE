import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, tap } from 'rxjs';
import { CurrentUser } from '../model/currentuser.model';
import { Router } from '@angular/router';

export interface AuthResponse {
  token: string, 
  expiration: string
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  rootUrl: string = 'http://localhost:5166/api/Login/Login';
  user: BehaviorSubject<CurrentUser | null> = new BehaviorSubject<CurrentUser | null>(null);

  constructor(private http: HttpClient, private router: Router) { }

  logInAuto(){
    let user = localStorage.getItem('user')
    if(user){
      let userJSON : CurrentUser = JSON.parse(user)
      this.user.next(userJSON)
    }
  }
  logOut(){
    localStorage.removeItem('user')
    this.user.next(null)
  }
}

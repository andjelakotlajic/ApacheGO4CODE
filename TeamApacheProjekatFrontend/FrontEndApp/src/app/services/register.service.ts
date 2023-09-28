import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from '../model/register.model';
import { Observable, catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  constructor(private http: HttpClient) { }

  register(user: Register) : Observable<any> {
    var url = 'http://localhost:5166/api/Login/Register';
    return this.http.post<any>(url, user).pipe(
      map(response => {
        return true
      })
    )
  }
}

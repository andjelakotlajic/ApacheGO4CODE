import { Component } from '@angular/core';
import { AuthResponse, AuthService } from '../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Subject, takeUntil } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginDto: any = {
    username: '', // Change "email" to "username"
    password: '',
  };
  errorMessage: string | null = null;
  private ngUnsubscribe = new Subject();
  constructor(private http: HttpClient,private router: Router) {}


  LogIn() {
    this.errorMessage = null;
    this.http
    .post('http://localhost:5166/api/Login/Login',this.loginDto,{ responseType: 'text' })
    .pipe(takeUntil(this.ngUnsubscribe))
    .subscribe((data) => {
      localStorage.clear()
      localStorage.setItem('authToken', data);
      console.log(localStorage);
      this.router.navigate(['/posts']);
    });
    ;
    
  }
}

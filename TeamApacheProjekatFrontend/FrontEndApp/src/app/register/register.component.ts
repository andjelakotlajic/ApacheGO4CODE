import { Component } from '@angular/core';
import { RegisterService } from '../services/register.service';
import { Register } from '../model/register.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  userTypeToRegister: string = "";
  sub: any
  username: string = "";
  firstName: string = "";
  lastName: string = "";
  mail: string = "";
  password: string = "";
  confirmPassword: string = "";
  errorInfo: string = "";
  constructor(private registerService: RegisterService, private router: Router){

  }
  ngOnInit(): void {
  }
  register() {
    this.registerService.register(new Register(this.username, this.firstName, this.lastName, this.mail, this.password)).subscribe({
      next: (data) => {
        alert('registered')
        this.router.navigate(['/login']) 
      } ,
      error: (data) => {
        alert('registration failed')
      }
      })
  }
}

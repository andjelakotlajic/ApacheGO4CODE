import { Component } from '@angular/core';
import { RegisterService } from '../services/register.service';
import { Register } from '../model/register.model';

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
  constructor(private registerService: RegisterService){

  }
  ngOnInit(): void {

  }
  register() {
    this.registerService.register(new Register(this.username, this.firstName, this.lastName, this.mail, this.password)).subscribe({
      next: (data) => {
        alert('registered') 
      } ,
      error: (data) => {
        alert('registration failed')
      }
      })
  }
}

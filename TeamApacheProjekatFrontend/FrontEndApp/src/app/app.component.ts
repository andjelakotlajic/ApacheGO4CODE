import { Component } from '@angular/core';
import { CommunicationService } from './services/communication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontEndApp';
  logedIn: boolean = false
  constructor(private communicationService: CommunicationService){
    this.communicationService.notifyParent$.subscribe(()=>{
      this.UpdateMenu()
    })
  }
  UpdateMenu(){
    let user = localStorage.getItem('authToken')
    if(user == null){
      this.logedIn = false
    }else{
      this.logedIn = true
    }
  }
  LogOut(){
    localStorage.clear()
    this.UpdateMenu()
  }
}

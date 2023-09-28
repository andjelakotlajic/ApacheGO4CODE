import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CommunicationService {
  private notifyParentSubject = new Subject<void>();

  notifyParent$ = this.notifyParentSubject.asObservable();

  notifyParent() {
    this.notifyParentSubject.next();
  }
}
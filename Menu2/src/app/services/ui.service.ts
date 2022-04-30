import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UIService {
  private showMenuItems:boolean=false;
  private subject=new Subject<any>();

  constructor() { }

  toggleShowMenuItems():void {
    this.showMenuItems=! this.showMenuItems;
    this.subject.next(this.showMenuItems)
  }

  onToggle(): Observable<any>{
    return this.subject.asObservable();
  }
}

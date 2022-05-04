import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UIService {
  private showMenuItems:boolean=false;
  private showMenus:boolean=false;
  private showAddOptions:boolean=false;
  private showEmployees:boolean=false;
  private showTrucks:boolean=false;
  private subject1=new Subject<any>();
  private subject2=new Subject<any>();
  private subject3=new Subject<any>();
  private subject4=new Subject<any>();
  private subject5=new Subject<any>();

  constructor() { }

  toggleShowMenuItems():void {
    this.showMenuItems=! this.showMenuItems;
    this.subject1.next(this.showMenuItems)
  }

  toggleShowMenus():void {
    this.showMenus=! this.showMenus;
    this.subject2.next(this.showMenus);
  }
  resetToggleShowMenus():void{
    this.showMenus=false;
    this.subject2.next(this.showMenus);
  }

  toggleShowAddOptions():void {
    this.showAddOptions=!this.showAddOptions;
    this.subject3.next(this.showAddOptions);
  }
  toggleShowTrucks():void{
    this.showTrucks=!this.showTrucks;
    this.subject5.next(this.showTrucks);
  }
  resetToggleShowAddOptions():void{
    this.showAddOptions=false;
    this.subject3.next(this.showAddOptions);
  }
  toggleShowEmployess():void{
    this.showEmployees=!this.showEmployees;
    this.subject4.next(this.showEmployees);
  }

  onToggleShowMenuItems(): Observable<any>{
    return this.subject1.asObservable();
  }

  onToggleShowMenus(): Observable<any>{
    return this.subject2.asObservable();
  }

  onToggleShowAddOptions():Observable<any>{
    return this.subject3.asObservable();
  }
  onToggleShowEmployees():Observable<any>{
    return this.subject4.asObservable();
  }
  onToggleShowTrucks():Observable<any>{
    return this.subject5.asObservable();
  }

}

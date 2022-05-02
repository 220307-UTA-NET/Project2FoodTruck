import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIurl="https://localhost:7217/api"

  constructor(private http:HttpClient) { }
  seeAllEmployee():Observable<any[]>{
    return this.http.get<any>(this.APIurl+'Employee/see/all/employees')
  }

  addEmployee(val:any){
    return this.http.post(this.APIurl+'/Employee/add/employee', val)
  }

  updateEmployee(val:any){
    return this.http.put(this.APIurl+'/Employee/update/employee{ID}', val)
  }

  deleteEmployee(val:any){
    return this.http.delete(this.APIurl+'/Employee/delete/employee{ID}'+ val)
  }

  getAllMenu():Observable<any[]>{
    return this.http.get<any>(this.APIurl+'/Menu/get/all/menu')
  }

  addMenu(val:any){
    return this.http.post(this.APIurl+'/Menu/add/menu', val)
  }

  updateMenu(val:any){
    return this.http.put(this.APIurl+'/Menu/update/menu{ID}', val)
  }

  deleteMenu(val:any){
    return this.http.delete(this.APIurl+'/Menu/delete/menu{ID}'+val)
  }

  seeAllMenuItem():Observable<any[]>{
    return this.http.get<any>(this.APIurl+'/MenuItem/see/all/menuItem')
  }

  createMenuItem(val:any){
    return this.http.post(this.APIurl+'/MenuItem/create/menuItem', val)
  }

  updateMenuItem(val:any){
    return this.http.put(this.APIurl+'/MenuItem/update/menuItem{ID}', val)
  }

  deleteMenuItem(val:any){
    return this.http.delete(this.APIurl+'/MenuItem/delete/menuItem{ID}'+val)
  }

  seeAllTruck():Observable<any[]>{
    return this.http.get<any>(this.APIurl+'/Truck/see/all/truck')
  }

  createMenuTruck(val:any){
    return this.http.post(this.APIurl+'/Truck/create/truck', val)
  }

  changeTruck(val:any){
    return this.http.put(this.APIurl+'/Truck/change/truck{ID}', val)
  }

  deleteMenuTruck(val:any){
    return this.http.delete(this.APIurl+'/Truck/delete/truck{ID}'+val)
  }

}

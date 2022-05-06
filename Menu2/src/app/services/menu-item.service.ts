import { Injectable } from '@angular/core';
import { MenuItem } from '../MenuItem';
import { Menu } from '../Menu';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions ={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  }),
};

@Injectable({
  providedIn: 'root'
})
export class MenuItemService {
  private menuItemUrl = 'https://footruckapi.azurewebsites.net/api/MenuItem'
  private menuUrl ='https://footruckapi.azurewebsites.net/api/Menus'


  constructor(private http:HttpClient) { }

  getMenuItems():Observable<MenuItem[]>{
    const url =`${this.menuItemUrl}/all`
    return this.http.get<MenuItem[]>(url)
  }

  deleteMenuItem(menuItem:MenuItem):Observable<MenuItem>{
    const url = `${this.menuItemUrl}/${menuItem.menuItemID}`;
    return this.http.delete<MenuItem>(url);
  }

  addMenuItem(menuItem: MenuItem):Observable<MenuItem>{
    return this.http.post<MenuItem>(this.menuItemUrl, menuItem, httpOptions);
  }

  updatePrice(menuItem: MenuItem):Observable<MenuItem>{
    const url =`${this.menuItemUrl}/priceChangeID`;
    return this.http.put<MenuItem>(url, menuItem, httpOptions);
  }

  addNewMenu(menuItemList:MenuItem[], menuName:string):Observable<Menu>{
    const url = `${this.menuUrl}?MenuName=${menuName}`;
    return this.http.post<Menu>(url, menuItemList, httpOptions);
  }
  getMenus():Observable<Menu[]>{
    return this.http.get<Menu[]>(this.menuUrl)
  }
  getOneMenu(menu:Menu):Observable<MenuItem[]>{
    const url =`${this.menuUrl}/${menu.menuID}`;
    return this.http.get<MenuItem[]>(url)
  }
  getMenuTest():Observable<MenuItem[]>{
    const url =`${this.menuUrl}/1`;
    console.log(url);
    return this.http.get<MenuItem[]>(url);
    
  }
  deleteMenu(menu:Menu):Observable<Menu>{
    const url=`${this.menuUrl}/${menu.menuID}`;
    return this.http.delete<Menu>(url);
  }
}

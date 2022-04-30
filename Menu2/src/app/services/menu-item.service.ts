import { Injectable } from '@angular/core';
import { MenuItem } from '../MenuItem';
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
  private apiUrl = 'https://localhost:7210/api/MenuItem'


  constructor(private http:HttpClient) { }

  getMenuItems():Observable<MenuItem[]>{
    const url =`${this.apiUrl}/all`
    return this.http.get<MenuItem[]>(url)
  }

  deleteMenuItem(menuItem:MenuItem):Observable<MenuItem>{
    const url = `${this.apiUrl}/${menuItem.menuItemID}`;
    return this.http.delete<MenuItem>(url);
  }

  addMenuItem(menuItem: MenuItem):Observable<MenuItem>{
    return this.http.post<MenuItem>(this.apiUrl, menuItem, httpOptions);
  }

  updatePrice(menuItem: MenuItem):Observable<MenuItem>{
    const url =`${this.apiUrl}/priceChangeID`;
    return this.http.put<MenuItem>(url, menuItem, httpOptions);
  }
}

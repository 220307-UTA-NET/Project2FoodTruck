import { Injectable } from '@angular/core';
import { Employee } from '../Employee';
import { Truck } from '../Trucks';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TruckDTO } from '../TruckDTO';
import { MenuItem } from '../MenuItem';

const httpOptions ={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  }),
};

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employeeUrl ='http://footruckapi.azurewebsites.net/api/Employees';
  private truckUrl='http://footruckapi.azurewebsites.net/api/Truck';

  constructor(private http:HttpClient) { }

  getEmployees():Observable<Employee[]>{
    const url =`${this.employeeUrl}/all`;
    return this.http.get<Employee[]>(url);
  }

  addNewEmployee(newEmployee:Employee):Observable<Employee>{
    return this.http.post<Employee>(this.employeeUrl, newEmployee, httpOptions);
  }

  deleteEmployee(employee:Employee):Observable<Employee>{
    const url=`${this.employeeUrl}/${employee.employeeID}`;
    return this.http.delete<Employee>(url);
  }

  getWorkersByTruck(truck:Truck):Observable<Employee[]>{
    const url =`${this.truckUrl}/employees${truck.truckID}`;
    return this.http.get<Employee[]>(url);
  }

  getTrucks():Observable<Truck[]>{
    const url=`${this.truckUrl}/all`;
    return this.http.get<Truck[]>(url);
  }
  createTruck(newTruck:TruckDTO):Observable<Truck>{
    return this.http.post<Truck>(this.truckUrl, newTruck, httpOptions);
  }
  setTruckToActive(truck:Truck):Observable<Truck[]>{
    const url =`${this.truckUrl}/${truck.truckID}`;
    return this.http.put<Truck[]>(url, httpOptions);
  }

  getTruckIsActive():Observable<MenuItem[]>{
    return this.http.get<MenuItem[]>(`${this.truckUrl}/true`);
  }
}

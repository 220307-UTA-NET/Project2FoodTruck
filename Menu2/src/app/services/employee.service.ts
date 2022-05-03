import { Injectable } from '@angular/core';
import { Employee } from '../Employee';
import { Truck } from '../Trucks';
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
export class EmployeeService {

  private employeeUrl ='https://localhost:7210/api/Employees';
  private truckUrl='https://localhost:7210/api/Trucks';

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

  getTrucks():Observable<Truck[]>{
    const url=`${this.truckUrl}/all`;
    return this.http.get<Truck[]>(url);
  }
}

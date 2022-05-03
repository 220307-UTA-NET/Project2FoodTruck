import { Component, OnInit } from '@angular/core';
import { Subscription} from 'rxjs';
import { UIService } from 'src/app/services/ui.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { Employee } from 'src/app/Employee';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees!: Employee[];
  showEmployees!:boolean;
  subscription!:Subscription;

  constructor(private uiService:UIService, private employeeService:EmployeeService) { 
    this.subscription=this.uiService.onToggleShowEmployees().subscribe(value=>this.showEmployees=value);
  }

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe((employees)=>this.employees=employees);
  }

  addNewEmployee(newEmployee:Employee)
  {
    this.employeeService.addNewEmployee(newEmployee).subscribe((newEmployee)=>(this.employees.push(newEmployee)));
  }

  deleteEmployee(employee:Employee)
  {
    this.employeeService.deleteEmployee(employee).subscribe(
      ()=>(this.employees=this.employees.filter(m=>m.employeeID !==employee.employeeID))
    );
  }

}

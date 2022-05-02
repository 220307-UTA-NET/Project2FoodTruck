import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Employee } from 'src/app/Employee';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  name!:string;
  phoneNumber!:string;
  @Output() onAddNewEmployee: EventEmitter<Employee> =new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  addNewEmployee()
  {
    const newEmployee={
      name:this.name,
      phoneNumber:this.phoneNumber
    }
    this.onAddNewEmployee.emit(newEmployee);
  }

}

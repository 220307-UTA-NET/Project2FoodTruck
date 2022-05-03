import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Employee } from 'src/app/Employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  @Input() employee!:Employee;
  @Output() onDeleteEmployee:EventEmitter<Employee>=new EventEmitter();
 
  constructor() { }

  ngOnInit(): void {
  }

  onDelete(employee:Employee)
  {
    this.onDeleteEmployee.emit(employee);
  }

}

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Employee } from 'src/app/Employee';
import { Subscription } from 'rxjs';
import { UIService } from 'src/app/services/ui.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  @Input() employee!:Employee;
  @Output() onDeleteEmployee:EventEmitter<Employee>=new EventEmitter();
  showTrucks!:Boolean;
  subscription!:Subscription;


 
  constructor(private uiService:UIService) { }

  ngOnInit(): void {
    this.subscription=this.uiService.onToggleShowTrucks().subscribe(value=>this.showTrucks=value);
  }

  onDelete(employee:Employee)
  {
    this.onDeleteEmployee.emit(employee);
  }

}

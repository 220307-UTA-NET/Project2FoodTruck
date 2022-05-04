import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Truck } from 'src/app/Trucks';
import { EmployeeService } from 'src/app/services/employee.service';
import { Employee } from 'src/app/Employee';

@Component({
  selector: 'app-truck',
  templateUrl: './truck.component.html',
  styleUrls: ['./truck.component.css']
})
export class TruckComponent implements OnInit {
  @Input() truck!:Truck;
  workers!:Employee[];
  @Output() onSetToActive: EventEmitter<Truck> =new EventEmitter();


  constructor(private employeeService:EmployeeService) { }

  ngOnInit(): void {
  }

  getWorkers(truck:Truck){
    this.employeeService.getWorkersByTruck(truck).subscribe((workers)=>this.workers=workers);
  }

  setToActive(truck:Truck){
    this.onSetToActive.emit(truck);
    //this.employeeService.setTruckToActive(truck).subscribe((trucks)=>this.trucks=trucks
  }

}

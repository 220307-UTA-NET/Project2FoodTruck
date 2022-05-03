import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { Truck } from 'src/app/Trucks';

@Component({
  selector: 'app-trucks',
  templateUrl: './trucks.component.html',
  styleUrls: ['./trucks.component.css']
})
export class TrucksComponent implements OnInit {
  showTrucks!:boolean;
  trucks!:Truck[]
  truck!:Truck;


  constructor(private employeeService:EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.getTrucks().subscribe((trucks)=>this.trucks=trucks);
  }

  deleteTruck(truck:Truck){}

  addNewTruck(){

  }
}

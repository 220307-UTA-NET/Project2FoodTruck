import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { UIService } from 'src/app/services/ui.service';
import { Truck } from 'src/app/Trucks';
import { Menu } from 'src/app/Menu';
import { Subscription } from 'rxjs';
import { Employee } from 'src/app/Employee';
import { MenuItemService } from 'src/app/services/menu-item.service';

@Component({
  selector: 'app-trucks',
  templateUrl: './trucks.component.html',
  styleUrls: ['./trucks.component.css']
})
export class TrucksComponent implements OnInit {
  showTrucks!:boolean;
  showCreateTruck!:boolean;
  menu!:Menu;
  menu1!:Menu;
  menus!:Menu[];
  workers:Employee[]=[];
  employee!:Employee;
  trucks!:Truck[]
  subscription!:Subscription;
  menuName!:string;
  menuID!:any;
  date!:Date;
  location!:string;
  employees!:Employee[];


  constructor(private employeeService:EmployeeService, private uiService:UIService, private menuItemService:MenuItemService) { }

  ngOnInit(): void {
    this.subscription=this.uiService.onToggleShowTrucks().subscribe(value=>this.showTrucks=value);
    this.employeeService.getTrucks().subscribe((trucks)=>this.trucks=trucks);

  }

  refreshData(){
    this.menuItemService.getMenus().subscribe((menus)=>this.menus=menus);
    this.employeeService.getEmployees().subscribe((employees)=>this.employees=employees);
    this.showCreateTruck=!this.showCreateTruck;
  }

  deleteTruck(truck:Truck){}

  addNewTruck(){

  }

  chooseMenu(menu:Menu){
    this.menuName =menu.menuName;
    this.menuID=menu.menuID;
    console.log(this.menuID);
  }

  chooseEmployees(employee:Employee){
    this.employee=employee;
    if(this.workers.includes(this.employee))
    {
      console.log(this.workers.indexOf(this.employee));
      this.workers.splice(this.workers.indexOf(this.employee),1);
    }
    else
    {
      this.workers.push(this.employee);
    }
    console.log(this.workers);
  }
  onSubmit()
  {
    const newTruck={
      date:this.date,
      menuID:this.menuID,
      location:this.location,
      employees:this.workers
    };
    this.employeeService.createTruck(newTruck).subscribe((truck)=>(this.trucks.push(truck)));
  }
  setActiveTruck(truck:Truck){
    this.employeeService.setTruckToActive(truck).subscribe((trucks)=>this.trucks=trucks);
  }
}

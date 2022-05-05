import { Component, OnInit } from '@angular/core';
import { UIService } from 'src/app/services/ui.service';
import { MenuItemService } from 'src/app/services/menu-item.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  title: string = 'Food Truck Setup'
  showMenuItems!:boolean;
  showMenus!:boolean;
  showAddOptions!:boolean;
  showEmployees!:boolean;
  showTrucks!:boolean;
  subscription!: Subscription;
  menuItemService!:MenuItemService;


  constructor(private uiService:UIService) {
   
   }

  ngOnInit(): void {
    this.subscription=this.uiService.onToggleShowMenuItems().subscribe(value=>this.showMenuItems=value);
    this.subscription=this.uiService.onToggleShowMenus().subscribe(value=>this.showMenus=value);
    this.subscription=this.uiService.onToggleShowAddOptions().subscribe(value=>this.showAddOptions=value);
    this.subscription=this.uiService.onToggleShowEmployees().subscribe(value=>this.showEmployees=value);
    this.subscription=this.uiService.onToggleShowTrucks().subscribe(value=>this.showTrucks=value);
  }

 
  toggleMenuItems(){
    this.uiService.toggleShowMenuItems();
  }

  toggleMenus(){
    this.uiService.toggleShowMenus();
  }
  
  toggleAddOptions(){
    this.uiService.toggleShowAddOptions();
  }
  toggleEmployees(){
    this.uiService.toggleShowEmployess();
  }
  toggleTrucks(){
    this.uiService.toggleShowTrucks();
  }

  resetShowAddOptions(){
    this.uiService.resetToggleShowAddOptions();
  }

  resetShowMenus(){
    this.uiService.resetToggleShowMenus();
  }


 


}

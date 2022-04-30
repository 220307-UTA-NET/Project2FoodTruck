import { Component, OnInit } from '@angular/core';
import  {MenuItem} from '../../MenuItem';
import { MenuItemService } from 'src/app/services/menu-item.service';
import { UIService } from 'src/app/services/ui.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  menuItems: MenuItem[]=[];
  showMenuItems!:boolean;
  subscription!:Subscription;

  constructor(private menuItemService: MenuItemService, private uiService:UIService) { 
    this.subscription=this.uiService.onToggle().subscribe(value=> this.showMenuItems=value)
  }

  ngOnInit(): void {
    this.menuItemService.getMenuItems().subscribe((menuItems)=>this.menuItems=menuItems);
  }

  deleteMenuItem(menuItem: MenuItem){
    console.log(menuItem);
    this.menuItemService
    .deleteMenuItem(menuItem)
    .subscribe(
      ()=>(this.menuItems=this.menuItems.filter(m=>m.menuItemID !==menuItem.menuItemID))
    );
  }

  addMenuItem(menuItem:MenuItem){
    this.menuItemService.addMenuItem(menuItem).subscribe((menuItem)=>(this.menuItems.push(menuItem)));
  }

  updatePrice(menuItem:MenuItem){
    this.menuItemService.updatePrice(menuItem).subscribe();
  }



}

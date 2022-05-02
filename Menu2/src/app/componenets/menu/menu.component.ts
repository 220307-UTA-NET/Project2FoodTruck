import { Component, OnInit, Input } from '@angular/core';
import  {MenuItem} from '../../MenuItem';
import { MenuItemService } from 'src/app/services/menu-item.service';
import { Menu } from 'src/app/Menu';
import { UIService } from 'src/app/services/ui.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  menuItems: MenuItem[]=[];
  menuItemList:MenuItem[]=[];
  menus!:Menu[];
  menu!:Menu;
  showMenus!:boolean;
  showMenuItems!:boolean;
  subscription!:Subscription;

  constructor(private menuItemService: MenuItemService, private uiService:UIService) { 
    this.subscription=this.uiService.onToggleShowMenuItems().subscribe(value=> this.showMenuItems=value)
    this.subscription=this.uiService.onToggleShowMenus().subscribe(value=> this.showMenus=value);
  }

  ngOnInit(): void {
    this.menuItemService.getMenuItems().subscribe((menuItems)=>this.menuItems=menuItems);
    this.menuItemService.getMenus().subscribe((menus)=>this.menus=menus);
  }

  deleteMenuItem(menuItem: MenuItem){
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

  addItemToNewMenu(menuItem:MenuItem)
  {
    let c=0;
    let toAdd=menuItem.foodType;

    if (this.menuItemList.indexOf(menuItem)>=0)
      {
        this.menuItemList.splice(this.menuItemList.indexOf(menuItem),1)
      }
    else 
    {
      for(let i=0; i<this.menuItemList.length; i++)
      {
        if(this.menuItemList[i].foodType === toAdd)
        {
          c++;  
        }              
      }
      if((c<2 && (toAdd==="Side"||toAdd==="Drink"))||(c<3 && (toAdd==="Main")))
      {
        this.menuItemList.push(menuItem);
      }

    }   
  }

  submitMenu(menuName:string)
  {
    this.menuItemService.addNewMenu(this.menuItemList, menuName).subscribe((menu)=>(this.menus.push(menu)));
    this.menuItemList.length=0; 
  }

  deleteMenu(menu:Menu)
  {
    this.menuItemService.deleteMenu(menu).subscribe(
      ()=>(this.menus=this.menus.filter(m=>m.menuID !==menu.menuID))
      );
  }




}

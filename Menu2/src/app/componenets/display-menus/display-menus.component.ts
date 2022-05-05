import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MenuItemService } from 'src/app/services/menu-item.service';
import { UIService } from 'src/app/services/ui.service';
import { Subscription } from 'rxjs';
import { Menu } from 'src/app/Menu';
import { MenuItem } from 'src/app/MenuItem';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'app-display-menus',
  templateUrl: './display-menus.component.html',
  styleUrls: ['./display-menus.component.css']
})
export class DisplayMenusComponent implements OnInit {
  @Input() menu!:Menu;
  menuItems!:MenuItem[];
  showMenus!:boolean;
  showTrucks!:boolean;
  subscription!:Subscription;
  displayingOneMenu:boolean=false;
  @Output() onDeleteMenu: EventEmitter<Menu>=new EventEmitter();


  constructor(private menuItemService: MenuItemService, private uiService:UIService) { 

  }

  ngOnInit(): void {
    this.subscription=this.uiService.onToggleShowMenus().subscribe(value=> this.showMenus=value);
    this.subscription=this.uiService.onToggleShowTrucks().subscribe(value=> this.showTrucks=value);
  }

  resetDisplayingOneMenu()
  {
    this.displayingOneMenu=false;
  }
  displayOneMenu(menu:Menu)
  {
    this.displayingOneMenu=!this.displayingOneMenu;
    this.menuItemService.getOneMenu(menu).subscribe((menuItems)=>this.menuItems=menuItems);
  }

  deleteMenu(menu:Menu)
  {
    this.onDeleteMenu.emit(menu);
  }





}

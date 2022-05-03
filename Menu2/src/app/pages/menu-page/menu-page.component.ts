import { Component, OnInit } from '@angular/core';
import { MenuItemService } from 'src/app/services/menu-item.service';
import { MenuItem } from 'src/app/MenuItem';

@Component({
  selector: 'app-menu-page',
  templateUrl: './menu-page.component.html',
  styleUrls: ['./menu-page.component.css']
})
export class MenuPageComponent implements OnInit {

    menuItems1:any=[];
  
    constructor(private menuItemService: MenuItemService) 
    {}
    ngOnInit(): void {
      this.refreshCurrrentMenu();   
    }
  
    refreshCurrrentMenu(){
      this.menuItemService.getMenuTest().subscribe(data=>{this.menuItems1=data;})
      console.log(this.menuItems1);
    }
  
  }

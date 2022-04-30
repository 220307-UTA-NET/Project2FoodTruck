import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MenuItem } from '../../MenuItem';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.css']
})
export class MenuItemComponent implements OnInit {
  @Input() menuItem!:MenuItem;
  @Output() onDeleteMenuItem: EventEmitter<MenuItem>=new EventEmitter();
  @Output() onPriceChange: EventEmitter<MenuItem>=new EventEmitter();
  showPriceChangeForm=false;
  price!:number;

  constructor() { }

  ngOnInit(): void {
  }

  toggleShowPriceChangeForm(){
    this.showPriceChangeForm=!this.showPriceChangeForm
  }

  onDelete(menuItem:MenuItem){
    console.log(menuItem, 'menu-item')
    this.onDeleteMenuItem.emit(menuItem);
  }
  updatePrice(menuItem:MenuItem){
    menuItem.price=this.price;
    this.price=0;
    this.onPriceChange.emit(menuItem);
  }
  

}

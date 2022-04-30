import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MenuItem } from 'src/app/MenuItem';


@Component({
  selector: 'app-add-menu-item',
  templateUrl: './add-menu-item.component.html',
  styleUrls: ['./add-menu-item.component.css']
})
export class AddMenuItemComponent implements OnInit {
  @Output() onAddMenuItem: EventEmitter<MenuItem>=new EventEmitter();
  foodType!: string;
  name!: string;
  description: string="";
  price!: number;
  isDisplay=false;

  constructor() { 

  }

  ngOnInit(): void {
    
  }


  toggleMenuItemForm(){
    this.isDisplay=!this.isDisplay;
  }

  onSubmit(){
    const newMenuItem={     
      foodType:this.foodType,
      name:this.name,
      description: this.description,
      price: this.price,
    };

    this.onAddMenuItem.emit(newMenuItem);
  }

}

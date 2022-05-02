import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MenuItem } from 'src/app/MenuItem';
import { UIService } from 'src/app/services/ui.service';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-add-menu-item',
  templateUrl: './add-menu-item.component.html',
  styleUrls: ['./add-menu-item.component.css']
})
export class AddMenuItemComponent implements OnInit {
  @Output() onAddMenuItem: EventEmitter<MenuItem>=new EventEmitter();
  foodType!: string;
  name!: string;
  description!: string;
  price!: number;
  isDisplay=false;
  showAddOptions!:boolean;
  subscription!:Subscription;
 

  constructor(private uiService:UIService) { 
    this.subscription=this.uiService.onToggleShowAddOptions().subscribe(value=> this.showAddOptions=value);
  }

  ngOnInit(): void {
    
  }


  toggleMenuItemForm(){
    this.isDisplay=!this.isDisplay;
  }

  onSubmit(){
    if(this.description===null|| this.description===undefined)
    {this.description="";}

    const newMenuItem={     
      foodType:this.foodType,
      name:this.name,
      description: this.description,
      price: this.price,
    };

    this.onAddMenuItem.emit(newMenuItem);
  }

}

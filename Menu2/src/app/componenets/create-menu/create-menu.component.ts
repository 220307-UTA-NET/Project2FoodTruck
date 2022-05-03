import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {MenuItem} from '../../MenuItem';
import { Subscription } from 'rxjs';
import { UIService } from 'src/app/services/ui.service';


@Component({
  selector: 'app-create-menu',
  templateUrl: './create-menu.component.html',
  styleUrls: ['./create-menu.component.css']
})
export class CreateMenuComponent implements OnInit {
  @Input() menuItem!:MenuItem;
  @Input() menuItemList!:MenuItem[];
  @Output() onSubmitMenu: EventEmitter<string>=new EventEmitter();
  menuName!:string;
  showAddOptions!:boolean;
  subscription!:Subscription;
 

  constructor(private uiService:UIService) { 
    this.subscription=this.uiService.onToggleShowAddOptions().subscribe(value=> this.showAddOptions=value);
  }

  ngOnInit(): void {
  }

  submitMenu()
    {
      this.onSubmitMenu.emit(this.menuName);
    }

  removeItem(menuItem:MenuItem)
  {
    this.menuItemList.splice(this.menuItemList.indexOf(menuItem),1)
  }



}

import { Component, OnInit } from '@angular/core';
import { UIService } from 'src/app/services/ui.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  title: string = 'Food Truck Setup'
  showMenuItems!:boolean;
  subscription!: Subscription;


  constructor(private uiService:UIService) {
    this.subscription=this.uiService.onToggle().subscribe(value=>this.showMenuItems=value)
   }

  ngOnInit(): void {
  }

 
  toggleMenuItems(){
    this.uiService.toggleShowMenuItems();
  }

}

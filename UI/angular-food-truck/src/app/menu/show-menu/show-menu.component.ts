import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-menu',
  templateUrl: './show-menu.component.html',
  styleUrls: ['./show-menu.component.css']
})
export class ShowMenuComponent implements OnInit {

  constructor(private service:SharedService) { }

  AllMenu:any=[];

  ngOnInit(): void {
    this.refreshAllMenu();
  }

  refreshAllMenu(){
    this.service.getAllMenu().subscribe(data=>{
      this.AllMenu=data;

    });
  }
}

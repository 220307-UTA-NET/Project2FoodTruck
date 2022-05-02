import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  AllMenu: any[] = []; 

  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.refreshAllMenu();
  }

  refreshAllMenu(){
    this.service.getAllMenu().subscribe(data=>{
      this.AllMenu=data;

    });
  }
}


import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menubar',
  templateUrl: './menubar.component.html',
  styleUrls: ['./menubar.component.css']
})
export class MenubarComponent implements OnInit {
  title: string = 'Welcome!';

  constructor() { }

  ngOnInit(): void {}

  toggleMenu(){
    console.log('toggleMenu');
  }

  toggleAboutUs(){
    console.log('toggleAboutUs');
  }

  toggleTruckLocation(){
    console.log('toggleTruckLocation');
  }

}

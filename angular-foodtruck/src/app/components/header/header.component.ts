import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header', //can use this selector to the app.component.html
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  title: string = 'Cosmic Food Truck';


  //the constructor runs when the component is initialize
  constructor() { }





  //this is a life cycle method
  //this what is used most of the time when a codes are initalize
  //when the component loads, it is placed here, ex.HTTP request
  ngOnInit(): void {
  }

}

import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-display-menus-button',
  templateUrl: './display-menus-button.component.html',
  styleUrls: ['./display-menus-button.component.css']
})
export class DisplayMenusButtonComponent implements OnInit {

  @Output() btnClickMenus = new EventEmitter();
  @Input() text!:string;

  constructor() { }

  ngOnInit(): void {
  }
  onClick(){
    this.btnClickMenus.emit();
  }

}

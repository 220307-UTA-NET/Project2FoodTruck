import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-truck-button',
  templateUrl: './truck-button.component.html',
  styleUrls: ['./truck-button.component.css']
})
export class TruckButtonComponent implements OnInit {

  @Output() btnClickTruck = new EventEmitter();
  @Input() text!:string;

  constructor() { }

  ngOnInit(): void {
  }
  onClick(){
    this.btnClickTruck.emit();
  }
}

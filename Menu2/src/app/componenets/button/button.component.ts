import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent implements OnInit {
  @Output() btnClick = new EventEmitter();
  @Output() btnAddClick = new EventEmitter();
  @Input() text!:string;

  constructor() { }

  ngOnInit(): void {
  }
  onClick(){

    this.btnClick.emit();
  }

}

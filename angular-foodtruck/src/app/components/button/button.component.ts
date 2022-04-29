import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent implements OnInit {
  @Input() text!: string;
  @Input() color!: string;
  @Output() btnClick = new EventEmitter();
  @Output() btnClick2 = new EventEmitter();
  @Output() btnClick3 = new EventEmitter();


  constructor() { }

  ngOnInit(): void {}
  onClick() {
    this.btnClick.emit();
    this.btnClick2.emit();
    this.btnClick3.emit();
  }
  

}

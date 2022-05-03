import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-add-options-button',
  templateUrl: './add-options-button.component.html',
  styleUrls: ['./add-options-button.component.css']
})
export class AddOptionsButtonComponent implements OnInit {
  @Output() btnClickAddOptions = new EventEmitter();
  @Input() text!:string;

  constructor() { }

  ngOnInit(): void {
  }
  onClick(){
    this.btnClickAddOptions.emit();
  }

}

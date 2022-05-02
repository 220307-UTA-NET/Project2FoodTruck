import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-employees-button',
  templateUrl: './employees-button.component.html',
  styleUrls: ['./employees-button.component.css']
})
export class EmployeesButtonComponent implements OnInit {

  @Output() btnClickEmployees = new EventEmitter();
  @Input() text!:string;

  constructor() { }

  ngOnInit(): void {
  }
  onClick(){
    this.btnClickEmployees.emit();
  }
}

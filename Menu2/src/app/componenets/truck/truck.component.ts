import { Component, OnInit, Input } from '@angular/core';
import { Truck } from 'src/app/Trucks';

@Component({
  selector: 'app-truck',
  templateUrl: './truck.component.html',
  styleUrls: ['./truck.component.css']
})
export class TruckComponent implements OnInit {
  @Input() truck!:Truck;

  constructor() { }

  ngOnInit(): void {
  }

}

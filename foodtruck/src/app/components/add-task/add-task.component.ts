import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs';
import { UiService } from '../../services/ui.service';
import {Task} from '../../Task';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {
  @Output() onAddTask: EventEmitter<Task> = new EventEmitter();
  FoodType!: string;
  Name!: string;
  Description!: string;
  Price!: number;
  reminder: boolean = true;
  showAddTask!: boolean;
  subscription : Subscription;


  constructor(private uiService:UiService) {
    this.subscription = this.uiService
    .onToggle()
    .subscribe((value) => (this.showAddTask = value));
   }

  ngOnInit(): void {
  }
  
  onSubmit(){
    
    if (!this.Name){

      alert('Please add a name!');
      return;
    }

    const newTask ={
      foodType: this.FoodType,
      name: this.Name,
      description: this.Description,
      price: this.Price,
      reminder: this.reminder,
    }
   console.log(newTask);
    this.onAddTask.emit(newTask);

    // this.FoodType ='';
    // this.Name = '';
    // this.Description ='';
    // this.Price = 0;
    // this.reminder = false;
    
  }
}

//this is the main class with properties and methods in it
import { Component } from '@angular/core';

@Component({
  //three items declared in this component declaration
  selector: 'app-root', //whatever the html tag is use to embed the component
  templateUrl: './app.component.html', //the html file you are using 
  styleUrls: ['./app.component.css'] //the style you are using - can have more than one
})
//this where you put any properties, methods and life cycle methods of the component 
export class AppComponent {
   
  
}

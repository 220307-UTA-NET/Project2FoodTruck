import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { ButtonComponent } from './components/button/button.component';
import { MenubarComponent } from './components/menubar/menubar.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ButtonComponent,
    MenubarComponent,
    
   
  ],
  imports: [
    BrowserModule //use to interact with the DOM
  ],
  providers: [], //any global services will associate with this
  bootstrap: [AppComponent]
})
export class AppModule { }

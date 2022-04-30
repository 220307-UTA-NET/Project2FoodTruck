import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { MenuItemComponent } from './componenets/menu-item/menu-item.component';
import { MenuComponent } from './componenets/menu/menu.component';
import { AddMenuItemComponent } from './componenets/add-menu-item/add-menu-item.component';
import { ButtonComponent } from './componenets/button/button.component';
import { HeaderComponent } from './componenets/header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuItemComponent,
    MenuComponent,
    AddMenuItemComponent,
    ButtonComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule, 
    FormsModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

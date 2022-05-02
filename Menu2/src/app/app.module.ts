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
import { CreateMenuComponent } from './componenets/create-menu/create-menu.component';
import { DisplayMenusComponent } from './componenets/display-menus/display-menus.component';
import { DisplayMenusButtonComponent } from './componenets/display-menus-button/display-menus-button.component';
import { AddOptionsButtonComponent } from './componenets/add-options-button/add-options-button.component';
import { EmployeesComponent } from './componenets/employees/employees.component';
import { EmployeesButtonComponent } from './componenets/employees-button/employees-button.component';
import { EmployeeComponent } from './componenets/employee/employee.component';
import { AddEmployeeComponent } from './componenets/add-employee/add-employee.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuItemComponent,
    MenuComponent,
    AddMenuItemComponent,
    ButtonComponent,
    HeaderComponent,
    CreateMenuComponent,
    DisplayMenusComponent,
    DisplayMenusButtonComponent,
    AddOptionsButtonComponent,
    EmployeesComponent,
    EmployeesButtonComponent,
    EmployeeComponent,
    AddEmployeeComponent,
    
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

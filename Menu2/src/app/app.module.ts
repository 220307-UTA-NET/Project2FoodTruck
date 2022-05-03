import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';

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
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { HomeComponent } from './pages/home/home.component';
import { NavbarComponent } from './sharedpage/navbar/navbar.component';
import { FooterComponent } from './sharedpage/footer/footer.component';
import { TrucksComponent } from './componenets/trucks/trucks.component';
import { TruckComponent } from './componenets/truck/truck.component';
import { AddTruckComponent } from './componenets/add-truck/add-truck.component';
import { MenuPageComponent } from './pages/menu-page/menu-page.component';
import { EmployeePageComponent } from './pages/employee-page/employee-page.component';

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
    AboutComponent,
    ContactComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    TrucksComponent,
    TruckComponent,
    AddTruckComponent,
    MenuPageComponent,
    EmployeePageComponent
    
  ],
  imports: [
    BrowserModule,
    HttpClientModule, 
    FormsModule,
    RouterModule,
    AppRoutingModule,
    ReactiveFormsModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

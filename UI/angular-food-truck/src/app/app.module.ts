import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedService } from './shared.service';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MenuComponent } from './menu/menu.component';
import { ShowMenuComponent } from './menu/show-menu/show-menu.component';
import { EmployeeComponent } from './employee/employee.component';
import { AddEditMenuComponent } from './menu/add-edit-menu/add-edit-menu.component';
import { AddEditEmpComponent } from './employee/add-edit-emp/add-edit-emp.component';
import { MenuitemComponent } from './menuitem/menuitem.component';
import { ShowMenuitemComponent } from './menuitem/show-menuitem/show-menuitem.component';
import { AddEditMenuitemComponent } from './menuitem/add-edit-menuitem/add-edit-menuitem.component';
import { TruckComponent } from './truck/truck.component';
import { ShowTruckComponent } from './truck/show-truck/show-truck.component';
import { AddEditTruckComponent } from './truck/add-edit-truck/add-edit-truck.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ShowAboutusComponent } from './aboutus/show-aboutus/show-aboutus.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ShowMenuComponent,
    EmployeeComponent,
    AddEditMenuComponent,
    AddEditEmpComponent,
    MenuitemComponent,
    ShowMenuitemComponent,
    AddEditMenuitemComponent,
    TruckComponent,
    ShowTruckComponent,
    AddEditTruckComponent,
    AboutusComponent,
    ShowAboutusComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }

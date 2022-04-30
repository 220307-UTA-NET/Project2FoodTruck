import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmployeeComponent } from './employee/employee.component';
import { MenuComponent } from './menu/menu.component';
import { MenuitemComponent } from './menuitem/menuitem.component';
import { TruckComponent } from './truck/truck.component';
import { AboutusComponent } from './aboutus/aboutus.component';


const routes: Routes = [
{path:'employee',component:EmployeeComponent},
{path:'menu',component:MenuComponent},
{path:'menuitem',component:MenuitemComponent},
{path:'truck',component:TruckComponent},
{path:'aboutus',component:AboutusComponent},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

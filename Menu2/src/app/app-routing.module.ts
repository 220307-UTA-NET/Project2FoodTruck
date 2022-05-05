import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { MenuPageComponent } from './pages/menu-page/menu-page.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { EmployeePageComponent } from './pages/employee-page/employee-page.component';
import { EmployeePortalComponent } from './pages/employee-portal/employee-portal.component';



const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'menu', component:MenuPageComponent},
  {path:'about', component:AboutComponent},
  {path:'contact', component:ContactComponent},
  {path:'employee', component:EmployeePageComponent},
  {path:'employee-portal', component:EmployeePortalComponent}
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
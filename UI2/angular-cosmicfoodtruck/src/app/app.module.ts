import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './sharedpage/navbar/navbar.component';
import { FooterComponent } from './sharedpage/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { MenuComponent } from './pages/menu/menu.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { ShowEmpComponent } from './pages/employee/show-emp/show-emp.component';
import { EditAddEmpComponent } from './pages/employee/edit-add-emp/edit-add-emp.component';
import { EditAddMenuComponent } from './pages/employee/edit-add-menu/edit-add-menu.component';
import { EditAddTruckComponent } from './pages/employee/edit-add-truck/edit-add-truck.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    MenuComponent,
    AboutComponent,
    ContactComponent,
    EmployeeComponent,
    ShowEmpComponent,
    EditAddEmpComponent,
    EditAddMenuComponent,
    EditAddTruckComponent
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

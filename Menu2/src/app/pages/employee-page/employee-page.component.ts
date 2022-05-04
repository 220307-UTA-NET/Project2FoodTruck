import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SignInData } from 'src/app/model/signInData';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';

@Component({
  selector: 'app-employee-page',
  templateUrl: './employee-page.component.html',
  styleUrls: ['./employee-page.component.css']
})
export class EmployeePageComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
  }

  onSubmit(signInForm: NgForm){
    console.log(signInForm.value);
    const signInData = new SignInData(signInForm.value.email, signInForm.value.password);
    this.authenticationService.authenticate(signInData);
  }

}

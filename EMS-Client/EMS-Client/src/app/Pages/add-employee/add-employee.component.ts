import { Component } from '@angular/core';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  emp= {
    fname:"",
    lname:"",
    phone:"",
    email:"",
    salary:0,
    location:"",
    department:"",
    password:""
  };

  submitEmployee(){
    console.log(this.emp);
  }
}

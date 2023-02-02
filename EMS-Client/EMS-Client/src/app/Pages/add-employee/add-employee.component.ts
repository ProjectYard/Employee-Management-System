import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  emp= {
    firstName:"",
    lastName:"",
    phone:"",
    email:"",
    salary:0,
    location:"",
    department:"",
    password:""
  };

  constructor(private http: HttpClient,private toastr: ToastrService) { 
    
  }

  clearObj(){
    this.emp.firstName="",
    this.emp.lastName="",
    this.emp.phone="",
    this.emp.email="",
    this.emp.salary=0,
    this.emp.location="",
    this.emp.department="",
    this.emp.password=""
  }

  postSuccess:boolean = false;

  submitEmployee(){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        // Authorization: 'my-auth-token',
        Authorization:`Bearer ${localStorage.getItem("tokenn")}`,
      })
    }
    console.log(this.emp);
    this.http.post("https://localhost:7092/api/Employee",this.emp,httpOptions).subscribe((data)=>{
      console.log(data);
      alert("Added Successfully")
    },(err)=>{
      alert("Not allowed");
      console.log("Not Allowed")
    });
    this.clearObj();
  }
}

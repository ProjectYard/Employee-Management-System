import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editcard',
  templateUrl: './editcard.component.html',
  styleUrls: ['./editcard.component.css']
})
export class EditcardComponent {
  @Input() editID = "";
  @Output() newItemEvent = new EventEmitter<boolean>();
  // @Input() emp2 = {
  //   firstName:"",
  //   lastName:"",
  //   phone:"",
  //   email:"",
  //   salary:0,
  //   location:"",
  //   department:"",
  //   password:""
  // } 

  // @Input() fn = "";

  // txt:string = this.fn;

  @Input() emp= {
    firstName:"",
    lastName:"",
    phone:"",
    email:"",
    salary:0,
    location:"",
    department:"",
    password:""
  };

  constructor(private http: HttpClient, private router: Router) { 
    
  }
  ngOnInit():void{

  }

  editEmployee(){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        // Authorization: 'my-auth-token',
        Authorization:`Bearer ${localStorage.getItem("tokenn")}`,
      })
    }
    const url = "https://localhost:7092/api/Employee/"+this.editID;
    this.http.put(url,this.emp,httpOptions).subscribe((data)=>{
      console.log(data);
    },(err)=>{
      alert("Not allowed");
      window.location.reload();
      console.log("Not Allowed")
    })

    console.log(url);
  }
}

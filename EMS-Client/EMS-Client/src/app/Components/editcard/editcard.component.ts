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

  constructor(private http: HttpClient, private router: Router) { 
    
  }
  ngOnInit():void{
  }
  editEmployee(){
    // const httpOptions = {
    //   headers: new HttpHeaders({
    //     'Content-Type':  'application/json',
    //     Authorization: 'my-auth-token'
    //   })
    // }
    const url = "https://localhost:44393/api/Employee/"+this.editID;
    this.http.put(url,this.emp).subscribe((data)=>{
      console.log(data);
    })

    console.log(url);
  }
}

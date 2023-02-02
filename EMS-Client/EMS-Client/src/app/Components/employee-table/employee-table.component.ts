import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-employee-table',
  templateUrl: './employee-table.component.html',
  styleUrls: ['./employee-table.component.css']
})
export class EmployeeTableComponent {

  getEmployeeValue:any;
  @Input() showAllButtonClicked:boolean = false;

  constructor(private http: HttpClient) { 
    
  }

  ngOnInit():void{
   this.getMethod(); 
  }

  edtHandler(){
    console.log("Testing")
  }

  editBtnHandler(){
    this.ngOnInit();
  }

  public getMethod(){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        // Authorization: 'my-auth-token',
        Authorization:`Bearer ${localStorage.getItem("tokenn")}`,
      })
    }
    this.http.get("https://localhost:7092/api/Employee",httpOptions).subscribe((data)=>{
      this.getEmployeeValue = data;
      console.log(data)
    });
  }

  Url = "https://localhost:7092/api/Employee";

  delBtnHandler(id:any){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        // Authorization: 'my-auth-token',
        Authorization:`Bearer ${localStorage.getItem("tokenn")}`,
      })
    }
    console.log(id);
    const url = this.Url+"?id="+id;
    this.http.delete(url,httpOptions).subscribe((data)=>{
      console.log(data);
      
      this.ngOnInit();
    },(err)=>{
      alert("Not allowed");
      console.log("Not Allowed")
    })
  }
}

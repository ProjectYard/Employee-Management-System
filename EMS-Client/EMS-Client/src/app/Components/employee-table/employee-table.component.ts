import { HttpClient } from '@angular/common/http';
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

  public getMethod(){
    this.http.get("https://localhost:44393/api/Employee").subscribe((data)=>{
      this.getEmployeeValue = data;
      console.log(data)
    });
  }
}

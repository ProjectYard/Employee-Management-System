import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  @Output() showAllEvent:EventEmitter<boolean> = new EventEmitter();
  clickedAll : boolean = true;
  inpUUID:string = "";
  getSearchedEmployeeValue:any;
  isEmpty:number = this.inpUUID.length;

  constructor(private http: HttpClient) { 
    
  }

  ngOnInit():void{
   this.getMethod(); 
  }

  public isInpEmpty(){
    if(this.inpUUID == "")
      return true;
    else
      return false;
  }

  public getMethod(){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        // Authorization: 'my-auth-token',
        Authorization:`Bearer ${localStorage.getItem("tokenn")}`,
      })
    }
      this.http.get("https://localhost:7092/api/Employee/"+this.inpUUID,httpOptions).subscribe((data)=>{
      console.log(data)
      this.getSearchedEmployeeValue = data;
      console.log(this.getSearchedEmployeeValue)
    });
  }

  ShowAllHandler(){
    if(this.clickedAll){
      this.showAllEvent.emit(true);
      this.clickedAll = false;
    }else{
      this.showAllEvent.emit(false);
      this.clickedAll = true;
    }
    
  }
}

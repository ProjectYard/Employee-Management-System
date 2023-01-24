import { HttpClient } from '@angular/common/http';
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
      this.http.get("https://localhost:44393/api/Employee/"+this.inpUUID).subscribe((data)=>{
      console.log(data)
      this.getSearchedEmployeeValue = data;
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

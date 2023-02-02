import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar2',
  templateUrl: './navbar2.component.html',
  styleUrls: ['./navbar2.component.css']
})
export class Navbar2Component {

  constructor(private router:Router) { 
    
  }
  continueHandler(){
    if(localStorage.getItem("tokenn")){
      this.router.navigate(["/Dash"])
    }
    else{
      this.router.navigate(["/login"])
    }
    
  }
}

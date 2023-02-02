import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  eml:any = localStorage.getItem('emp')

  constructor(private router:Router) { 
    
  }

  IconHandler(){
    if(localStorage.getItem('tokenn')){
      this.router.navigate(["/Dash"])
    }else{
      this.router.navigate(["/"])
    }
  }
  
  LogOut(){
    localStorage.removeItem('tokenn')
    this.router.navigate(["/"])
  }
}

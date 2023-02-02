import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email:string='';
  pass:string='';

  constructor(private http: HttpClient, private router:Router) { 
    
  }

  loginHandler(){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        Authorization: 'my-auth-token'
      })
    }

    const person = {
      email:this.email,
      password:this.pass
    }

    const url = "https://localhost:7092/login?Email="+this.email+"&Password="+this.pass;
    console.log(url)
    this.http.post(url,person).subscribe((data:any)=>{
      console.warn(data.tokenn);
      localStorage.setItem("tokenn",data.tokenn);
      localStorage.setItem("emp",this.email);
      this.router.navigate(['/Dash']);
    },(err)=>{
      alert("Wrong Email or Password, Check it again")
    });
  }
}

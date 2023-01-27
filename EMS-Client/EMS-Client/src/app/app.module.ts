import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashComponent } from './Pages/dash/dash.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { SearchComponent } from './Components/search/search.component';
import { EmployeeTableComponent } from './Components/employee-table/employee-table.component';
import { FormsModule } from '@angular/forms';
import { SearchCardComponent } from './Components/search-card/search-card.component';
import { AddEmployeeComponent } from './Pages/add-employee/add-employee.component';
import { HomeComponent } from './Pages/home/home.component';
import { Navbar2Component } from './Components/navbar2/navbar2.component';
import { EditcardComponent } from './Components/editcard/editcard.component';

const appRoute:Routes = [
  {path:'Home',component:HomeComponent},
  {path:'Dash',component:DashComponent},
  {path:'Add',component:AddEmployeeComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    DashComponent,
    NavbarComponent,
    SearchComponent,
    EmployeeTableComponent,
    SearchCardComponent,
    AddEmployeeComponent,
    HomeComponent,
    Navbar2Component,
    EditcardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule, 
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoute), 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

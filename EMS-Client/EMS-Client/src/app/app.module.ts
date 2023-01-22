import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashComponent } from './Pages/dash/dash.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { SearchComponent } from './Components/search/search.component';
import { EmployeeTableComponent } from './Components/employee-table/employee-table.component';

@NgModule({
  declarations: [
    AppComponent,
    DashComponent,
    NavbarComponent,
    SearchComponent,
    EmployeeTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

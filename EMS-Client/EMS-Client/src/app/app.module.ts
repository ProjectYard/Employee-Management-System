import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashComponent } from './Pages/dash/dash.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { SearchComponent } from './Components/search/search.component';
import { EmployeeTableComponent } from './Components/employee-table/employee-table.component';
import { FormsModule } from '@angular/forms';
import { SearchCardComponent } from './Components/search-card/search-card.component';

@NgModule({
  declarations: [
    AppComponent,
    DashComponent,
    NavbarComponent,
    SearchComponent,
    EmployeeTableComponent,
    SearchCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

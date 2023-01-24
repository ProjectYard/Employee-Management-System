import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-search-card',
  templateUrl: './search-card.component.html',
  styleUrls: ['./search-card.component.css']
})
export class SearchCardComponent {

  @Input() fname:string = "";
  @Input() lname:string = "";
  @Input() phone:string = "";
  @Input() email:string = "";
  @Input() department:string = "";
  @Input() location:string = "";


}

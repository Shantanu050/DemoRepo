import { Component, OnInit } from '@angular/core';
import { Employee } from '../employee';

@Component({
  selector: 'app-simple',
  templateUrl: './simple.component.html',
  styleUrls: ['./simple.component.css']
})
export class SimpleComponent implements OnInit {
weekdays:string[]=['sunday','monday','tuesday','wednesday','thursday','friday','saturday']
age:number=30
emp:Employee={id:1,name:'Tom',salary:40000,city:'Pune'}
emplist:Employee[]=[
  {id:1,name:'Tom',salary:40000,city:'Pune'},
  {id:2,name:'John',salary:40000,city:'Mumbai'},
  {id:3,name:'Shantanu',salary:40000,city:'Pune'},
  {id:4,name:'Rhyth',salary:40000,city:'Mumbai'},
]
GetTotal():number
{
  var total:number=0;
  for(let i of this.emplist)
  {
    total+=i.salary;
  }
  return total
}
  constructor() { }

  ngOnInit() {
  }

}


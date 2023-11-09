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
emp:Employee=(id:1,name:'Tom',salary:40000,city:'Pune')
  constructor() { }

  ngOnInit() {
  }

}


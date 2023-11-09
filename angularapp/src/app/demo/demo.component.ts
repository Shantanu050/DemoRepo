import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
  styleUrls: ['./demo.component.css']
})
export class DemoComponent implements OnInit {

  name:string="Tom"
  age:number=30
  fno:number=49
  sno:number=50
  Sum():number
  {
    return this.fno+this.sno
  }
  Show():void
  {
    alert('Name is '+this.name+"Age is"+this.age)
  }
  constructor() { }

  ngOnInit() {
  }

}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor() { }
  
RegisterStudent(stdForm:NgForm):void
{
  console.log(stdForm.value)
  console.log(stdForm.value.firstname)
  
}
  ngOnInit() {
  }

}

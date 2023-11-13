import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { stringify } from 'querystring';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor() { }
  fName:string
RegisterStudent(stdForm:NgForm):void
{
  console.log(stdForm.value)
  console.log(stdForm.value.firstname)
  fName=stdForm.value.firstname
}
  ngOnInit() {
  }

}

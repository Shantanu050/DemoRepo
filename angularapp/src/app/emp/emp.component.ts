import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup,FormControl,Validator } from '@angular/forms';

@Component({
  selector: 'app-emp',
  templateUrl: './emp.component.html',
  styleUrls: ['./emp.component.css']
})
export class EmpComponent implements OnInit {

  constructor(private formbuilder:FormBuilder) 
  { 

  }
  empform=this.formbuilder.group({
    firstname:[''],
    age['']
  })
  ngOnInit() {
  }

}

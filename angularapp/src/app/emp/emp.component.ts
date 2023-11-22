import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
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
    name:['',[Validators.required,Validators.maxLength(30)]],
    email:['',Validators.email],
    city:['',Validators.pattern("[a-zA-Z]")]
  })
  Save(form:FormGroup):void{
    console.log(this.empform.value)
  }
  // empform=this.formbuilder.group({
  //   firstname:[''],
  //   age:[''],
  //   address:this.formbuilder.group({
  //     line1:[''],
  //     city:[''],
  //     state:['']
  //   })
  // })

  ngOnInit() {
  }

}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { IMovie } from '../model/imovie';
import { MovieserviceService } from '../services/movieservice.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-reactiveform',
  templateUrl: './reactiveform.component.html',
  styleUrls: ['./reactiveform.component.css']
})
export class ReactiveformComponent implements OnInit {
moviedata:IMovie
  constructor(private fb:FormBuilder,private ms:MovieserviceService,private route:Router) { }
movieform=this.fb.group({
name:['',Validators.required],
yearrelease:['',[Validators.required,Validators.min(2000),Validators.max(2023)]],
rating:['',[Validators.required,Validators.min(1),Validators.max(5)]]
}
)
saveData():void
{
  this.moviedata=this.movieform.value
  if(this.moviedata.rating>5)
  {
    alert('Error in ratings')
    return
  }
  console.log(this.moviedata)
  //subscribr service here
  this.ms.addMovie(this.moviedata).subscribe(()=>
  {
    alert('Movie Added!!')
    this.route.navigate(['/listmovies'])
    
  })
}

  ngOnInit() {
  }

}

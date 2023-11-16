import { Component, OnInit } from '@angular/core';
import { IMovie } from '../model/imovie';
import { MovieserviceService } from '../services/movieservice.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-addmovie',
  templateUrl: './addmovie.component.html',
  styleUrls: ['./addmovie.component.css']
})
export class AddmovieComponent implements OnInit {

  moviedata:IMovie={id:0,name:"",yearrelease:0,rating:0}
  constructor(private ms:MovieserviceService,private route:Router) { }
  saveData(movie:IMovie):void
  {
    this.moviedata=movie
    this.ms.addMovie(this.moviedata).subscribe(()=>
     {
      alert('Record Added')
      this.route.navigate(['/listmovies'])
      }
    )
  }

  ngOnInit() {
  }

}

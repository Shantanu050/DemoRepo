import { Component, OnInit } from '@angular/core';
import { MovieService } from '../MovieService/movie.service';
import { IMovie } from '../model/imovie';
@Component({
  selector: 'app-list-movie',
  templateUrl: './list-movie.component.html',
  styleUrls: ['./list-movie.component.css']
})
export class ListMovieComponent implements OnInit {
moviedata:IMovie[]=[]
  constructor(private movieService:MovieService) { 
    this.movieService.getAllMovies().subscribe(data=>{this.moviedata.push(...data)})
    console.log(this.moviedata)
  }

  ngOnInit() {
  }

}

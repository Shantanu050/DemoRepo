import { Component, OnInit } from '@angular/core';
import { IMovie } from '../model/imovie';
import { MovieService } from '../MovieService/movie.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-findmovie',
  templateUrl: './findmovie.component.html',
  styleUrls: ['./findmovie.component.css']
})
export class FindmovieComponent implements OnInit {
moviedata:IMovie
id:number
  constructor(private movieservice:MovieService,private ar:ActivatedRoute){}

  ngOnInit() 
  {
    const tid=this.ar.snapshot.paramMap.get('id')
    this.id=Number(tid)
    this.movieservice.getMovie(this.id).subscribe((data:IMovie)=>
    {
   this.moviedata=data
    })
  }

}

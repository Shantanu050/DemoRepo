import { Component, OnInit } from '@angular/core';
import { IMovie } from '../model/imovie';
import { MovieserviceService } from '../services/movieservice.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-editmovie',
  templateUrl: './editmovie.component.html',
  styleUrls: ['./editmovie.component.css']
})
export class EditmovieComponent implements OnInit {

  constructor(private ms:MovieserviceService,private route:Router,private ar:ActivatedRoute) { }
  moviedata:IMovie
  id:number
getMovie(id:number)
{ 
  this.ms.getMovie(id).subscribe((data:IMovie)=>this.moviedata=data)
}

EditData(movie :IMovie)
{
  this.moviedata=movie
  this.ms.editMovie(this.moviedata).subscribe(()=>
  {
    alert('Edited')
    this.route.navigate(['/listmovies'])
  })
}
  ngOnInit()
   {
    const tid=this.ar.snapshot.paramMap.get('id')
    this.id=Number(tid)
    this.getMovie(this.id)
  }

}

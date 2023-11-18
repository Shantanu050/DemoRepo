import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMovie } from '../model/imovie';
import { MovieserviceService } from '../services/movieservice.service';
@Component({
  selector: 'app-findmovie',
  templateUrl: './findmovie.component.html',
  styleUrls: ['./findmovie.component.css']
})
export class FindmovieComponent implements OnInit {

  moviedata:IMovie
  id:number
  constructor(private ms:MovieserviceService,private ar:ActivatedRoute,private route:Router) {
    const tid=this.ar.snapshot.paramMap.get('id')
    this.id=Number(tid)
    this.ms.getMovie(this.id).subscribe((data:IMovie)=>
    this.moviedata=data)
   }
Show()
{
  this.route.navigate(['/listmovies'])
}
  ngOnInit() {
  
  }

}

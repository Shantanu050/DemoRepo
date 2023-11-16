import { Component, OnInit } from '@angular/core';
import { MovieserviceService } from '../services/movieservice.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IMovie } from '../model/imovie';

@Component({
  selector: 'app-deletemovie',
  templateUrl: './deletemovie.component.html',
  styleUrls: ['./deletemovie.component.css']
})
export class DeletemovieComponent implements OnInit {

  moviedata:IMovie={id:0,name:'',rating:0,yearrelease:0}
  id:number
  constructor(private ms:MovieserviceService,private ar:ActivatedRoute,private route:Router) { 
    const tid= this.ar.snapshot.paramMap.get('id')
    this.id=Number(tid)
    this.ms.getMovie(this.id).subscribe((data:IMovie)=>
    {
      this.moviedata=data
    })

  }
  DeleteData(data:IMovie)
  {
    this.ms.deleteMovie(this.id).subscribe(()=>
    {
      alert('Record Deleted')
      this.route.navigate(['/listmovies'])
    })
  }

  ngOnInit() {
  }

}

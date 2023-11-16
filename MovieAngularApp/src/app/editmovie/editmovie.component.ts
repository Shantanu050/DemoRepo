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
  moviedata:IMovie={id:0,name:'',rating:0,yearrelease:0}
  id:number
getMovie(id:number)
{ 
  

}
  ngOnInit()
   {
    const tid=this.ar.snapshot.paramMap.get('id')
    this.id=Number(tid)

  }

}

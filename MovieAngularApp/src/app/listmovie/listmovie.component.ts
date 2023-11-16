import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IMovie } from '../model/imovie';
import { MovieserviceService } from '../services/movieservice.service';

@Component({
  selector: 'app-listmovie',
  templateUrl: './listmovie.component.html',
  styleUrls: ['./listmovie.component.css']
})
export class ListmovieComponent implements OnInit {
moviedata:any[]=[]
  constructor(private service:MovieserviceService) 
  {
    this.service.getAllMovies().subscribe(data=>{this.moviedata.push(...data)})
    console.log(this.moviedata)
  }

  ngOnInit() {
  }

}

import { Component, OnInit } from '@angular/core';
import { MovieserviceService } from '../services/movieservice.service';
import { Router } from '@angular/router';
import { Idetails } from '../model/idetails';
import { IMovie } from '../model/imovie';

@Component({
  selector: 'app-createdetails',
  templateUrl: './createdetails.component.html',
  styleUrls: ['./createdetails.component.css']
})
export class CreatedetailsComponent implements OnInit {
detailsdata:Idetails={detailId:0,actor:'',movieId:0,gender:'',n}
showmovies:IMovie[]=[]
  constructor(private ms:MovieserviceService, private route:Router) { }

  ngOnInit() {
  }

}

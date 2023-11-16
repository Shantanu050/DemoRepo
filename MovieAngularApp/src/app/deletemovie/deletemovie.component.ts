import { Component, OnInit } from '@angular/core';
import { MovieserviceService } from '../services/movieservice.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-deletemovie',
  templateUrl: './deletemovie.component.html',
  styleUrls: ['./deletemovie.component.css']
})
export class DeletemovieComponent implements OnInit {

  constructor(private ms:MovieserviceService,private ar:ActivatedRoute,private route:Router) { 
    const tid= this.ar.snapshot.paramMap.get('id')
    

  }

  ngOnInit() {
  }

}

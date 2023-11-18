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
detailsdata:Idetails={detailId:0,actor:'',movieId:0,gender:'',role:''}
showdata:any[]=[]
  constructor(private ms:MovieserviceService, private route:Router) {

   }
saveData(data:Idetails):void
{
  this.detailsdata=data
  this.ms.addDetails(this.detailsdata).subscribe(()=>
  {
    alert('Record Added')
    this.route.navigate(['/listmovies'])
  })
}
  ngOnInit() {
    this.ms.getAllMovies().subscribe(data=>{this.showdata.push(...data)})
  }

}

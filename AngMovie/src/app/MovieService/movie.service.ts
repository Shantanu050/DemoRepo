import { Injectable } from '@angular/core';
import { IMovie } from '../model/imovie'; 
import{HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MovieService {
private url='https://8080-bfebfcbdbbfabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/Movie';
  constructor(private httpClient:HttpClient ) { }

  getAllMovies():Observable<IMovie[]>
  {
    return this.httpClient.get<IMovie[]>(`${this.url}/ListMovies`)
  }
  movie:IMovie
  getMovie(id:number):Observable<IMovie>
  {
    return this.httpClient.get<IMovie>(this.url+'/ListMovies/'+id)
  }
}

import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import {IMovie} from '../model/imovie'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MovieserviceService {
private url='https://8080-bfebfcbdbbfabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/Movie';

  constructor(private http:HttpClient) { }
  getAllMovies():Observable<any[]>
  {
    return this.http.get<any[]>(this.url+'/ListMovies')
  }
  getMovie(id:number):Observable<IMovie>
  {
   return this.http.get<IMovie>(this.url+'/ListMovies/'+id)
  }

  httpOptions={headers:new HttpHeaders({'Content-type':'application/json'})}
  addMovie(moviedata:IMovie):Observable<IMovie>
  {
    return this.http.post<IMovie>(this.url+'/AddMovie',moviedata,this.httpOptions)
  }
}

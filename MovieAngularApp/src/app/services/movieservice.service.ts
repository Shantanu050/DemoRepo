import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse,HttpHeaders} from '@angular/common/http'
import {IMovie} from '../model/imovie'
import { Observable } from 'rxjs';
import { Idetails } from '../model/idetails';
import{catchError} from 'rxjs/operators';
import {throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieserviceService {
private url='https://8080-bfebfcbdbbfabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/Movie';
private detailUr="https://8080-bfebfcbdbbfabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/Detail"
  constructor(private http:HttpClient) { }
  getAllMovies():Observable<any[]>
  {
    return this.http.get<any[]>(this.url+'/ListMovies')
  }
  getMovie(id:number):Observable<IMovie>
  {
   return this.http.get<IMovie>(this.url+'/ListMovies/'+id).pipe(catchError(this.handleError));
  }

  httpOptions={headers:new HttpHeaders({'Content-type':'application/json'})}
  addMovie(moviedata:IMovie):Observable<IMovie>
  {
    return this.http.post<IMovie>(this.url+'/AddMovie',moviedata,this.httpOptions)
  }

  editMovie(moviedata:IMovie):Observable<IMovie>
  {
    return this.http.put<IMovie>(this.url+'/EditMovie/'+moviedata.id,moviedata,this.httpOptions).pipe(catchError(this.handleError));
  }

  deleteMovie(id:number):Observable<IMovie>
  {
    return this.http.delete<IMovie>(this.url+'/Delete/'+id).pipe(catchError(this.handleError));
  }
  addDetails(detailsdata:Idetails):Observable<Idetails>
  {
    return this.http.post<Idetails>(this.detailUr+'/AddDetails',detailsdata,this.httpOptions)
  }

  handleError(error:HttpErrorResponse)
  {
    var errmsg=error.status+'\n'
  }
}

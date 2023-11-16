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
}

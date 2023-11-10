import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
DisplayService(name:string):string
{
  return "Hello "+name
}
  constructor() { }
}

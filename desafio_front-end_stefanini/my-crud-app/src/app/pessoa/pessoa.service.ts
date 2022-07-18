import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Pessoa } from './pessoa';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  private apiURL = "http://localhost:5194/api";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  getUfs(){

    return ['BA','SP','RJ','MG']
  }

  getAll(): Observable<Pessoa[]> {
    return this.httpClient.get<Pessoa[]>(this.apiURL + '/Pessoa/')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  create(Pessoa): Observable<Pessoa> {
    return this.httpClient.post<Pessoa>(this.apiURL + '/Pessoa/', JSON.stringify(Pessoa), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  find(id): Observable<Pessoa> {
    return this.httpClient.get<Pessoa>(this.apiURL + '/Pessoa/' + id)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  update(id, Pessoa): Observable<Pessoa> {
    return this.httpClient.put<Pessoa>(this.apiURL + '/Pessoa/' + id, JSON.stringify(Pessoa), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  delete(id){
    return this.httpClient.delete<Pessoa>(this.apiURL + '/Pessoa/' + id, this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }


  errorHandler(error) {

    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.error.error}`;
    }
    return throwError(errorMessage);
 }
}

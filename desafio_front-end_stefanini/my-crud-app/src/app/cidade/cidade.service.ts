import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Cidade } from './cidade';


@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  private apiURL = "http://localhost:5194/api";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  getUfs(){

    return [{ uf: 'BA' }, { uf: 'SP' }, { uf: 'RJ' }, { uf: 'MG' }]
  }

  getAll(): Observable<Cidade[]> {
    return this.httpClient.get<Cidade[]>(this.apiURL + '/Cidade/')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  create(Cidade): Observable<Cidade> {
    return this.httpClient.post<Cidade>(this.apiURL + '/Cidade/', JSON.stringify(Cidade), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  find(id): Observable<Cidade> {
    return this.httpClient.get<Cidade>(this.apiURL + '/Cidade/' + id)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  update(id, Cidade): Observable<Cidade> {
    return this.httpClient.put<Cidade>(this.apiURL + '/Cidade/' + id, JSON.stringify(Cidade), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  delete(id){
    return this.httpClient.delete<Cidade>(this.apiURL + '/Cidade/' + id, this.httpOptions)
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

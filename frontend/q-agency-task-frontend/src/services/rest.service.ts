import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { Email } from 'src/models/Email';
import { Importance } from 'src/models/Importance';

@Injectable({
  providedIn: 'root'
})
export class RestService {

  apiURL = 'https://localhost:7240';
  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };
  
  getEmails(): Observable<Email> {
    return this.http
      .get<Email>(this.apiURL + '/api/Email/email')
      .pipe(retry(1), catchError(this.handleError));
  }

  getImportanceLevels(): Observable<Importance> {
    return this.http
      .get<Importance>(this.apiURL + '/api/Email/importance')
      .pipe(retry(1), catchError(this.handleError));
  }

  addEmail(email: any): Observable<Email> {
    return this.http
      .post<Email>(
        this.apiURL + '/api/Email',
        JSON.stringify(email),
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }
  
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}

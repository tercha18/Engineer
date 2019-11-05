import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { retry, catchError } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';
import { Statement } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url = 'http://localhost:55944/api/auth';
  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public Login(model: LoginModel): Promise<any> {
    return this.http.post(this.url + '/login', JSON.stringify(model), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    )
    .toPromise();
  }

  public Register(model: FormModel): Observable<Statement> {
    return this.http.post<Statement>(this.url + '/register', JSON.stringify(model), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
 }
}

export interface LoginModel {
  username: string;
  password: string;
}

export interface FormModel {
  username: string;
  password: string;
  height: number;
  weight: number;
}

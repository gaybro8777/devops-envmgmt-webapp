import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class AuthenticationService {
  myAppUrl: string = "";
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getUser() {
    console.log('Calling getUser');
    //: Observable<string>
    //return this._http.get(this.myAppUrl + 'auth/getuser', { responseType: 'text' })
    return this._http.get(this.myAppUrl + 'auth/getuser')
      .pipe(catchError(this.handleError));
      //.map((rslt: string) => {
      //  return rslt;
      //});
  }

  handleError(error: Response) {
    if ((<any>error).error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', (<any>error).error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${(<any>error).error}`);
    }

    return new ErrorObservable("There was an error.  Please inspect the console logs.");
  }
}

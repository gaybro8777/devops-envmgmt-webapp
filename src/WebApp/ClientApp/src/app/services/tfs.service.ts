import { Injectable, Inject } from '@angular/core';
//import { Http, Response } from '@angular/http';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class TfsService {
  myAppUrl: string = "";
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
  }
  getTFSLabels() {
    return this._http.get(this.myAppUrl + 'api/TFSLabels')
      .pipe(catchError(this.handleError));
          //.map((response: Response) => response.json())
          //.catch(this.errorHandler);
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
    
    return new ErrorObservable("There was an error from tfs.service.ts.  Please inspect the console logs.");
  }
}

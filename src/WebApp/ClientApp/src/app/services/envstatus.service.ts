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
export class EnvStatusService {
    myAppUrl: string = "";
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }
    getEnvStatus() {
      return this._http.get(this.myAppUrl + 'api/EnvStatus')
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
    getEnvStatusById(id: number) {
      return this._http.get(this.myAppUrl + "api/EnvStatus/" + id)
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
    saveEnvStatus(envstatus) {
      return this._http.post(this.myAppUrl + 'api/EnvStatus', envstatus)
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
    updateEnvStatus(id: number, envstatus) {
      return this._http.put(this.myAppUrl + "api/EnvStatus/" + id, envstatus)
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
    deleteEnvStatus(id) {
      return this._http.delete(this.myAppUrl + "api/EnvStatus/" + id)
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
    
    return new ErrorObservable("There was an error.  Please inspect the console logs.");
  }
}

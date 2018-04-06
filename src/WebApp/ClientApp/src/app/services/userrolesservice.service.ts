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
export class UserRolesService {
    myAppUrl: string = "";
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }
    getUserRoles() {
      return this._http.get(this.myAppUrl + 'api/UserRoles')
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
    getUserRoleById(id: number) {
      return this._http.get(this.myAppUrl + "api/UserRoles/" + id)
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
    saveUserRole(user) {
      return this._http.post(this.myAppUrl + 'api/Users', user)
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
    updateUserRole(id: number, user) {
      return this._http.put(this.myAppUrl + "api/UserRoles/" + id, user)
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
    deleteUserRole(id) {
      return this._http.delete(this.myAppUrl + "api/UserRoles/" + id)
        .pipe(catchError(this.handleError));
            //.map((response: Response) => response.json())
            //.catch(this.errorHandler);
    }
  handleError(error: Response) {
    //if (error.error instanceof ErrorEvent) {
    //  // A client-side or network error occurred. Handle it accordingly.
    //  console.error('An error occurred:', error.error.message);
    //} else {
    //  // The backend returned an unsuccessful response code.
    //  // The response body may contain clues as to what went wrong,
    //  console.error(
    //    `Backend returned code ${error.status}, ` +
    //    `body was: ${error.error}`);
    //}
    // return an ErrorObservable with a user-facing error message
    return new ErrorObservable('Something bad happened; please try again later.');
  }
}

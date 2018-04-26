import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpClientModule, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError, retry } from 'rxjs/operators';
//import * as ad2 from 'activedirectory2';
//import * as activedirectory2 from 'activedirectory2';
// import 'activedirectory2';
//const ad2 = require('activedirectory2');
import * as Filter from 'ldap-filters';
import * as LdapStrategy from 'passport-ldapauth';
import * as express from 'express';
import * as passport from 'passport';
import * as bodyParserfrom from 'body-parser';
import * as ldapjs from 'ldapjs';

@Injectable()
export class AuthenticationService {
  myAppUrl: string = "";

  config = {
    url: 'ldap://motadcprd0013.MOTIVA.PRV',
    baseDN: 'OU=Users,OU=Motiva,DC=motiva,DC=prv',
    username: 'richard.nunez@motiva.com',
    password: 'Qwerqwer@2'
  }

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getUser() {
    //console.log('Calling getUser');
    //: Observable<string>
    //return this._http.get(this.myAppUrl + 'auth/getuser', { responseType: 'text' })
    return this._http.get(this.myAppUrl + 'auth/getuser')
      .pipe(catchError(this.handleError));
      //.map((rslt: string) => {
      //  return rslt;
      //});
  }

  // motiva.prv:motadcprd0013@MOTIVA.PRV
  // OU=Users,OU=Motiva,DC=motiva,DC=prv
  //_config: adal.Config = {
  //  tenant: 'ldap://MOTADCPRD0013.motiva.prv'
  //}

  public sneak(): any {
    let profile: string;
    console.log("Starting to get ldap record...");

    //const ad2: any = require('activedirectory2');
    //let ad = new activedirectory2(this.config);

    let sAMAccountName = 'Richard.Nunez';

    let output = Filter.AND([
      Filter.attribute('givenName').equalTo('Richard'),
      Filter.attribute('sn').equalTo('Nunez')
    ]);
    console.log(output.toString());

    
    let ldap ={
      server: {
        url: 'ldap://MOTADCPRD0013.motiva.prv:389',
        bindDN: 'richard.nunez@motiva.com',
        bindCredentials: 'Qwerqwer@2',
        searchBase: 'ou=users,dc=motiva,dc=prv',
        searchFilter: '(&(givenName=Richard)(sn=Nunez))',
        reconnect: true
      }
    };
    //passport.use(new LdapStrategy(ldap));
    //let auth = passport.use(ldap);


    //ad.findUser(sAMAccountName, function (err, user) {
    //  if (err) {
    //    console.log('ERROR: ' + JSON.stringify(err));
    //    return;
    //  }
    //  if (!user) console.log('User: ' + sAMAccountName + ' not found.');
    //  else console.log(JSON.stringify(user));
    //});


    //let AD = new ad2(this.config);
    //console.log("made it!");
  //  this.adal5Service.config(this._config);
  //  return this.adal5Service.userInfo;
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

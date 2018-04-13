export interface IAuthenticationResultModel {
  authenticationType: string;
  isAuthenticated: string;
  name: string;
  domain: string;
  login: string;
}

export class AuthenticationResultModel implements IAuthenticationResultModel {

  public authenticationType: string;
  public isAuthenticated: string;
  public name: string;
  public domain: string;
  public login: string;


  constructor(obj?: IAuthenticationResultModel) {
    if (obj != null) {
      Object.assign(this, obj);
    }
  }
}

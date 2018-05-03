
import { Injectable } from '@angular/core';

@Injectable()
export class StateService {
  public disabled = {
    'envrequestformPage': false, 'blankmenuPage': false, 'updateenvdashboardPage': false,
    'adminPage': false, 'adminRetrieveUserPage': false, 'addminAdduserPage': false
  };
}

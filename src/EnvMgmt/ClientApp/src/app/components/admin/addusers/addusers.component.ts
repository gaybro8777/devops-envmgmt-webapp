import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { FormBuilder, FormGroup } from '@angular/forms';
//import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { RetrieveUsersComponent } from '../retrieveusers/retrieveusers.component';
import { UsersService } from '../../../services/users.service';
import { User } from '../../../models/user';

@Component({
    selector: 'adduser',
    templateUrl: './addusers.component.html',
    styleUrls: ['./addusers.component.css']
})
export class adduser implements OnInit {

  user: User = {
    userID: 0,
    firstName: '',
    lastName: '',
    isActive: 0
  };
    title: string = "Create";
    id: number;
    errorMessage: any;
    apiStatus: string = "failure";

    constructor(public http: HttpClient, private _router: Router,
      private _userService: UsersService, private _avRoute: ActivatedRoute) {

      if (this._avRoute.snapshot.params["id"]) {
        this.id = this._avRoute.snapshot.params["id"];
      }
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this._userService.getUserById(this.id)
              .subscribe(resp => this.user = resp
                    , error => this.errorMessage = error);
        }
    }

    save(f) {
      // if (!this.userForm.valid) {
      // return;
      // }
        if (this.title == "Create") {
            this._userService.saveUser(this.user)
                .subscribe((data) => {
                  this._router.navigate(['admin/retrieve-user']);
                }, error => this.errorMessage = error)
          // console.info(f.value);
        }
        else if (this.title == "Edit") {
            this._userService.updateUser(this.id, this.user).subscribe((data) => {
                if (data.status == 'success') {
                  this._router.navigate(['admin/retrieve-user']);
                } else {
                    console.log("API Error: The Update API returned status of: failure.")
                    throw new Error('The Update API call failed.');
                }
            }, error => this.errorMessage = error)
        }
    }

    cancel() {
      this._router.navigate(['/admin/retrieve-user']);
  }

  isActive_onChange(event) {
    //console.log(event.checked);
    if (event.checked) {
      this.user.isActive = 1;
    }
    else {
      this.user.isActive = 0;
    }
  }
}

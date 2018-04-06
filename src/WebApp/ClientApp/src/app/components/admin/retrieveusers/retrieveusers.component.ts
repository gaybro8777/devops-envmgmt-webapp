import { Component, Inject } from '@angular/core';
//import { Http, Headers } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from '../../../services/usersservice.service';
import { User } from "../../../models/user";

@Component({
    selector: 'retrieveusers',
    templateUrl: './retrieveusers.component.html'
})
export class RetrieveUsersComponent {
  public usersList: User[];
    constructor(public http: HttpClient, private _router: Router, private _usersService: UsersService) {
        this.getUsers();
    }

    getUsers() {
        this._usersService.getUsers().subscribe(
            data => this.usersList = data
        )
    }

    delete(UserID) {
        var ans = confirm("Do you want to delete User with Id: " + UserID);
        if (ans) {
            this._usersService.deleteUser(UserID).subscribe((data) => {
                this.getUsers();
            }, error => console.error(error))
        }
    }
}

import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '@app/_models';
import { UserService } from '@app/_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    loading = false;
    users: User[];
    currentUser:any;

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.loading = true;
        var u = JSON.parse(localStorage.getItem('currentUser'));
        this.currentUser = u.user.username;
            this.userService.getAll().pipe(first()).subscribe(users => {
            this.loading = false;
            this.users = users;
        });
    }
}
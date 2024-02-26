import { Component, OnInit } from '@angular/core';
import { UsersService } from '../_services/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users : any | null = null;

  constructor(private userService : UsersService){}

  ngOnInit(): void {
    this.userService.getAllUsers()
    .subscribe({
      next: users => { this.users = users; console.log(users); }
    });
  }

  deleteUser(id : any) {
  }
}

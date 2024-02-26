import { Component, OnInit } from '@angular/core';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  currentUser : any;
  userLogin: string | null = null;
  userPassword: string | null = null;

  constructor(private accountService : AccountsService) {}

  ngOnInit(): void {
    this.currentUser = this.accountService.getCurrentUser().user;
  }

  login() {
    if (!this.userLogin || !this.userPassword) return;

    this.accountService.login(this.userLogin, this.userPassword)
      .subscribe({
        next: user => { this.currentUser = user.user; console.log(user) },
        error: err => console.error(err)
      });
  }

  logout() {
    this.accountService.logout(this.currentUser);
    this.currentUser = null;
  }
}

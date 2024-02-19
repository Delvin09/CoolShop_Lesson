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
    this.currentUser = this.accountService.getCurrentUser();
  }

  login() {
    if (!this.userLogin || !this.userPassword) return;

    this.accountService.login(this.userLogin, this.userPassword)
      .subscribe({
        next: user => { this.currentUser = user; console.log('User login') },
        error: err => console.error(err)
      });
  }

  logout() {

    this.accountService.logout(this.currentUser)
    .subscribe({
      complete: () => this.currentUser = null,
      error: err => console.error(err)
    });
  }
}

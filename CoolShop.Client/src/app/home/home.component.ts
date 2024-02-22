import { Component } from '@angular/core';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private accountService: AccountsService) {}

  isLogin() : boolean {
    if (this.accountService.getCurrentUser())
      return true;
    return false;
  }
}

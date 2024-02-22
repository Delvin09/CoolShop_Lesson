import { Component } from '@angular/core';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  model: any;

constructor(private accountService: AccountsService) {}

  onRegister() {
    this.accountService.register(this.model);
  }
}

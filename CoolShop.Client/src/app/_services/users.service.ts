import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountsService } from './accounts.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private client : HttpClient, private accountService: AccountsService) { }

  getAllUsers() {
    const token = this.accountService.getCurrentUser().token;
    return this.client.get('https://localhost:7234/api/account/list', { headers: { 'Authorization': 'Bearer ' + token } });
  }

  updateUser(model: any) {
    return this.client.put('https://localhost:7234/api/account/' + model.Id, model);
  }
}
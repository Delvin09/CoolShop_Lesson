import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private client : HttpClient) { }

  getAllUsers() {
    return this.client.get('https://localhost:7234/api/account/list');
  }

  updateUser(model: any) {
    return this.client.put('https://localhost:7234/api/account/' + model.Id, model);
  }
}
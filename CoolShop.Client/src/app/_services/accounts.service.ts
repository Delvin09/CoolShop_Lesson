import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  constructor(private client : HttpClient) { }

  login(login : string, password : string) {
    return this.client.post<any>('https://localhost:7234/api/account/login', { login, password })
      .pipe(
        map(user => {
          localStorage.setItem('user', JSON.stringify(user));
          return user;
        })
      );
  }

  logout(user : any) {
    localStorage.removeItem('user');
  }

  register(model: any) {
    return this.client.post<any>('https://localhost:7234/api/account/register/user', model)
      .pipe(
        map(user => {
          localStorage.setItem('user', JSON.stringify(user));
          return user;
        })
      );
  }

  getCurrentUser() : any {
    const user = localStorage.getItem('user');
    if (user) 
      return JSON.parse(user);
    return null;
  }
}

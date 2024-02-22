import { Component } from '@angular/core';
import { UsersService } from '../_services/users.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {

  model: any;

  constructor(private userService: UsersService) {}

  onSubmit() {
    this.userService.updateUser(this.model);
  }
}

import { Component, OnInit } from '@angular/core';
import { LoginService, LoginModel } from '../../services/LoginService';
import * as HttpStatus from 'http-status-codes';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private loginService: LoginService) {}

  public model: LoginModel = {
    password: '',
    username: ''
  };

  show = false;
  result: any;

  ngOnInit(): void {

  }

  async signIn() {
    try {
      this.result = await this.loginService.Login(this.model);
      if (this.result === HttpStatus.OK) {
        alert('Ok');
      }
    } catch (ex) {
      console.log(ex);
    }
  }
}

/* tslint:disable-next-line: one-line */
import { Component, OnInit } from '@angular/core';
import { LoginService, FormModel } from '../../services/LoginService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private loginService: LoginService, private router: Router) { }

  public model: FormModel = {
    password: '',
    username: '',
    height: 0,
    weight: 0
  };
  passwordConfirm = '';
  result: any;

  ngOnInit() {
  }

  async register(): Promise<boolean> {
      try {
        if (this.passwordConfirm === this.model.password) {
          if(this.model.password.length > 2)
          {
            this.loginService.Register(this.model).subscribe(data => this.result = data);
            alert('Ok');
            this.router.navigateByUrl('/');
          }
          else {
            alert('Za krótkie hasło.');
          }
        }
        else {
          alert('Niezgodne hasła.');
        }
      }
      catch (ex) {
        alert('ERROR!' + ex);
        return false;
      }
      return true;
  }
}

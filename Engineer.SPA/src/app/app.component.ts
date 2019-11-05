import { Component, ErrorHandler } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'EngineerWeb';
}

export interface FormModel {
    username: string;
    password: string;
}

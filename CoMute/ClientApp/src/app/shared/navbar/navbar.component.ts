import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})

export class AppNavbarComponent implements OnInit {

  constructor(private _authService:AuthService){}
  ngOnInit(): void {
    
  }

  async isUserAuthenticated(){
    //return await this._authService.isAuthenticated();
  }

}

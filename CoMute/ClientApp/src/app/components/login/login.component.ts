import { AuthService } from './../../services/auth.service';
import { InputValidation, InputType } from './../../models/input-validation.model';
import { Component, OnInit } from '@angular/core';
import { AuthenticationResult } from '../../models/authentication-result.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  LoginSuccess?: boolean;
  Message: string ="";
  AlertType: string = "alert-danger";

  Email:InputValidation = new InputValidation(InputType.Email, "");
  Password:InputValidation = new InputValidation(InputType.Password, "");

  constructor(private _authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    
  }

  async login(){

    if(this.loginFormIsValid()){

      let result = await this._authService.authenticate(this.Email.Value, this.Password.Value);
      console.log("result at login:");
      console.log(result);

      this.LoginSuccess = result.isSuccess;
      this.Message = result.message;

      if (result.isSuccess) {

        this.AlertType = "success";
        this.router.navigate(['home']);
      }

    }
    else
    {
      this.Email.validateInput();
      this.Password.validateInput();
    }
  }

  loginFormIsValid(){
   
    if(this.Email.IsValid && this.Password.IsValid){
      return true;
    }
    else
    {
      return false;
    }

  }

}

import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import axios from 'axios';
import { __read } from 'tslib';
import { AuthenticationResult } from '../models/authentication-result.model';

axios.defaults.headers.common = { 'Authorization': `bearer ${localStorage.getItem('token') ?? ""}` }
//console.log(localStorage.getItem('token'));

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _router: Router) {}

  async isAuthenticated(){

    console.log("isAuthenticated: Fired");
    let result = false;

    await axios.get('/User/Authenticated')
      .then(function (response) {
        console.log("Authentication: Success");
        console.log(response);
        result = true;
      })
      .catch(function (error) {
        console.log("Authentication: Fail");
        console.log(error);
      })

    console.log(`Returning Result: ${result}`);
    return result;
  }
  async authenticate(email:string, password:string) {

    console.log("authenticate: Fired");

   let result = await axios({
      method: "post",
      url: "/User/Authenticate",
      headers: {
        'Content-Type': 'application/json'
      },
      data: {
        email: email,
        password: password,
      }
      })
      .then(function(response) {

        console.log("authenticate request response:");
        console.log(response);

        let data = response.data as AuthenticationResult;

        console.log('authentication result data:');
        console.log(data);

        if (data.isSuccess) {

          console.log(response.data);
          console.log("authentication success:");
          localStorage.setItem('token', data.accessToken ?? "")
          localStorage.setItem('userName', data.userName ?? "")

          //return { isSuccess: true, message: "Successful" } as AuthenticationResult;


        } else {

          console.log("authentication failed:");
          //return { isSuccess: false, message: "Wrong email or password" } as AuthenticationResult;

        }

        return data;

      })
      .catch(function (error) {

        console.log("authentication error:");
        console.log(error);
        return { isSuccess: false, message: "Something went wrong and it's not your fault." } as AuthenticationResult;

      })

    console.log('Returning Result:');
    console.log(result);
    return result;

  }

  signUp(email:string, password:string) {
    alert("TODO: User login")
  }


}


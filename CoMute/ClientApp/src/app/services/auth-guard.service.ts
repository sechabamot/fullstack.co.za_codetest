import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private auth: AuthService, private router: Router) { }

  async canActivate() {

    console.log("canActivate: Fired");

    const result = await this.auth.isAuthenticated();
    if(!result)
    { 
      this.router.navigate(['login']);
      return false;
    }
    // this.router.navigate(['home']);
    return true;

  }
}

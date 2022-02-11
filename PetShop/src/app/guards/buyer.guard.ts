import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';

@Injectable({
  providedIn: 'root',
})
export class BuyerGuard implements CanActivate {
  constructor(
    private srvAuthentication: AuthenticationService,
    private router: Router
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let isAuthenticate = this.srvAuthentication.isBuyer();
    if (!isAuthenticate) {
      this.router.navigateByUrl('/auth/login');
    }
    return isAuthenticate;
  }
}

import { Injectable } from '@angular/core';
import { UserService } from '../user/usuario.service';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivateChild } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class HomeGuard implements CanActivate {

    constructor(
        private userService: UserService,
        private router: Router) { }
    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {

        if (this.userService.isLogged()) {
            return true;
        }
        this.router.navigate([''])
        return false;
    }
}
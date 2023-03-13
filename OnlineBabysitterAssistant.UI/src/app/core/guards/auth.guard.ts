import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { UserType } from 'src/app/shared/models/user-type';

import { AuthenticationService } from '../services/auth.service';
import { NotificationService } from '../services/notification.service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router,
        private notificationService: NotificationService,
        private authService: AuthenticationService) { }

    // canActivate() {
    //     const user = this.authService.getCurrentUser();

    //     if (user && user.expiration) {

    //         if (moment() < moment(user.expiration)) {
    //             return true;
    //         } else {
    //             this.notificationService.openSnackBar('Your session has expired');
    //             this.router.navigate(['auth/login']);
    //             return false;
    //         }
    //     }

    //     this.router.navigate(['auth/login']);
    //     return false;
    // }
    checkUserLogin(route: ActivatedRouteSnapshot): boolean {
        const user = this.authService.getCurrentUser();

        if (user && user.expiration) {
            const userRole: UserType = UserType[user.type];
            const roles = route.data['roles'] as UserType[];
            if (roles && roles.indexOf(userRole) !== -1 && moment() < moment(user.expiration)) {
                return true;
            } else {
                this.notificationService.openSnackBar('Your session has expired');
                this.router.navigate(['auth/login']);
                return false;
            }
        }

        this.router.navigate(['auth/login']);
        return false;
    }
    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        let url: string = state.url;
        return this.checkUserLogin(next);
    }
}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { delay, map } from 'rxjs/operators';
import jwt_decode from 'jwt-decode';
import * as moment from 'moment';

import { environment } from '../../../environments/environment';
import { of, EMPTY } from 'rxjs';
import { LoginUser } from 'src/app/shared/models/login-user';
import { AuthUser } from 'src/app/shared/models/auth-user';
import { RegisterUser } from 'src/app/shared/models/register-user';
import { UpdateUserInfo, UserModel } from 'src/app/shared/models/user-model';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    constructor(private http: HttpClient,
        @Inject('LOCALSTORAGE') private localStorage: Storage) {
    }

    login(loginUser: LoginUser) {
        
        return this.http.post<AuthUser>(`${environment.apiUrl}/api/auth/login`, loginUser)
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                
                const decoded = jwt_decode(user.token);
                user.expiration = new Date((decoded as {exp:number}).exp * 1000);
                user.alias = user.email.split('@')[0]
                localStorage.setItem('currentUser', JSON.stringify(user));

                return true;
            }));
    }

    register(registerUser: RegisterUser){
        return this.http.post<any>(`${environment.apiUrl}/api/auth/register`, registerUser)
            .pipe();
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.localStorage.removeItem('currentUser');
    }

    getCurrentUser(): AuthUser {
        // TODO: Enable after implementation
        return JSON.parse(this.localStorage.getItem('currentUser') || '{}');
    }

    getUserInfo(){
        var userId = this.getCurrentUser().id;
        return this.http.get<UserModel>(`${environment.apiUrl}/api/auth/info/${userId}`);
    }

    updateUserInfo(profile: UpdateUserInfo){
        let currentUser = this.getCurrentUser();
        return this.http.put<UserModel>(`${environment.apiUrl}/api/auth`, profile).pipe(map(user => {
            currentUser.email = user.email;
            currentUser.name = user.name;
            this.localStorage.setItem('currentUser', JSON.stringify(currentUser));
        }))
    }

    passwordResetRequest(email: string) {
        return of(true).pipe(delay(1000));
    }

    changePassword(email: string, currentPwd: string, newPwd: string) {
        return of(true).pipe(delay(1000));
    }

    passwordReset(email: string, token: string, password: string, confirmPassword: string): any {
        return of(true).pipe(delay(1000));
    }
}

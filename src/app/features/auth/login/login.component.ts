import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { AuthenticationService } from 'src/app/core/services/auth.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { first } from 'rxjs';
import { LoginUser } from 'src/app/shared/models/login-user';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    loginForm!: FormGroup;
    loading!: boolean;

    constructor(private router: Router,
        private titleService: Title,
        private notificationService: NotificationService,
        private authenticationService: AuthenticationService) {
    }

    ngOnInit() {
        this.titleService.setTitle('Online Babysitter Assistant - Login');
        this.authenticationService.logout();
        this.createForm();
    }

    private createForm() {
        const savedUsername = localStorage.getItem('savedUsername');

        this.loginForm = new FormGroup({
            username: new FormControl(savedUsername, [Validators.required]),
            password: new FormControl('', Validators.required),
            rememberMe: new FormControl(savedUsername !== null)
        });
    }

    login() {
        const rememberMe = this.loginForm.get('rememberMe')?.value;

        let loginUser =  <LoginUser>{
            username: this.loginForm.get('username')?.value,
            password: this.loginForm.get('password')?.value
        };


        this.loading = true;
        this.authenticationService
            .login(loginUser).pipe(first())
            .subscribe({
                next: () => {
                    if (rememberMe) {
                        localStorage.setItem('savedUsername', loginUser.username);
                    } else {
                        localStorage.removeItem('savedUsername');
                    }
                    this.router.navigate(['/']);
                },
                error: error => {
                    this.notificationService.openSnackBar(error.error);
                    this.loading = false;
                }
            });
    }

    resetPassword() {
        this.router.navigate(['/auth/password-reset-request']);
    }

    register(){
        this.router.navigate(['/auth/register']);
    }
}

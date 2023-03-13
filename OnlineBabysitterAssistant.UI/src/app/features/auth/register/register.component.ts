import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/auth.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { RegisterUser } from 'src/app/shared/models/register-user';
import { UserType } from 'src/app/shared/models/user-type';
import { first } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  loading!: boolean;
  userTypes = UserType;
  enumKeys: string[] = [];
  constructor(private router: Router,
    private titleService: Title,
    private notificationService: NotificationService,
    private authenticationService: AuthenticationService) {
    this.enumKeys = Object.keys(this.userTypes).filter(f => !isNaN(Number(f)));
  }

  ngOnInit(): void {
    this.titleService.setTitle('Online Babysitter Assistant - Login');
    this.authenticationService.logout();
    this.createForm();
  }

  private createForm() {
    this.registerForm = new FormGroup({
      name: new FormControl('', Validators.required),
      username: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required),
      phoneNumber: new FormControl('', Validators.required),
      address: new FormControl(''),
      type: new FormControl(null, Validators.required)
    });
  }

  register() {
    let registerUser = <RegisterUser>{
      name: this.registerForm.get('name')?.value,
      userName: this.registerForm.get('username')?.value,
      email: this.registerForm.get('email')?.value,
      password: this.registerForm.get('password')?.value,
      phoneNumber: this.registerForm.get('phoneNumber')?.value,
      address: this.registerForm.get('address')?.value,
      type: this.registerForm.get('type')?.value
    }

    this.authenticationService
      .register(registerUser).pipe(first())
      .subscribe({
        next: () => {
          this.notificationService.openSnackBar("Account is created successfully!");
          this.login();
        },
        error: error => {
          this.notificationService.openSnackBar(error.error);
          this.loading = false;
        }
      });

  }

  login() {
    this.router.navigate(['/auth/login']);
  }

}

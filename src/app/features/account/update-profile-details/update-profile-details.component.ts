import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NGXLogger } from 'ngx-logger';
import { AuthenticationService } from 'src/app/core/services/auth.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { SpinnerService } from 'src/app/core/services/spinner.service';
import { UpdateUserInfo } from 'src/app/shared/models/user-model';
import { first } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update-profile-details',
  templateUrl: './update-profile-details.component.html',
  styleUrls: ['./update-profile-details.component.css']
})
export class UpdateProfileDetailsComponent implements OnInit {

  form!: FormGroup;
  disableSubmit!: boolean;
  constructor(private authService: AuthenticationService,
    private router: Router,
    private logger: NGXLogger,
    private spinnerService: SpinnerService,
    private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      address: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      phoneNumber: new FormControl('', Validators.required)
    });

    this.authService.getUserInfo().subscribe({
      next: result => {
        this.form.patchValue({
          name: result.name,
          address: result.address,
          email: result.email,
          phoneNumber: result.phoneNumber
        })
      },
      error: error =>{
        console.log(error);
        this.notificationService.openSnackBar(error.error.message);
      }
    })

    this.spinnerService.visibility.subscribe((value) => {
      this.disableSubmit = value;
    });
  }

  updateProfile(){

    let profile = <UpdateUserInfo>{
      id: this.authService.getCurrentUser().id,
      name: this.form.get('name')?.value,
      address: this.form.get('address')?.value,
      email: this.form.get('email')?.value,
      phoneNumber: this.form.get('phoneNumber')?.value
    }
    this.authService.updateUserInfo(profile).pipe(first()).subscribe({
      next: result=>{
        this.notificationService.openSnackBar('Successfully updated profile');
        window.location.reload();
      },
      error: error =>{
        this.notificationService.openSnackBar(error.error.message);
      }
    });
    
  }
}

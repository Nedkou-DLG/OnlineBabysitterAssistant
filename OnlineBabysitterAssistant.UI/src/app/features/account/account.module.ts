import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { AccountPageComponent } from './account-page/account-page.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { UpdateProfileDetailsComponent } from './update-profile-details/update-profile-details.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    AccountRoutingModule
  ],
  declarations: [AccountPageComponent, ChangePasswordComponent, ProfileDetailsComponent, UpdateProfileDetailsComponent],
  exports: [AccountPageComponent]
})
export class AccountModule { }

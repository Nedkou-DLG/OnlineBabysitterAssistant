import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './core/guards/auth.guard';
import { UserType } from './shared/models/user-type';

const appRoutes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule),
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./features/dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [AuthGuard],
    data: {
      roles: [UserType.BABYSITTER, UserType.PARENT]
    }
  },
  {
    path: 'children',
    loadChildren: () => import('./features/children/children.module').then(m => m.ChildrenModule),
    canActivate: [AuthGuard],
    data: {
      roles: [UserType.BABYSITTER, UserType.PARENT]
    }
  },
  {
    path: 'relationships',
    loadChildren: () => import('./features/relationships/relationships.module').then(m => m.RelationshipsModule),
    canActivate: [AuthGuard],
    data: {
      roles: [UserType.BABYSITTER, UserType.PARENT]
    }
  },
  {
    path: 'account',
    loadChildren: () => import('./features/account/account.module').then(m => m.AccountModule),
    canActivate: [AuthGuard],
    data: {
      roles: [UserType.BABYSITTER, UserType.PARENT]
    }
  },
  {
    path: 'about',
    loadChildren: () => import('./features/about/about.module').then(m => m.AboutModule),
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }

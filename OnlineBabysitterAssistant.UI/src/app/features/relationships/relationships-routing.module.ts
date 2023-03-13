import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { BabysitterListComponent } from './babysitter-list/babysitter-list.component';
import { ParentsListComponent } from './parents-list/parents-list.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'babysitters', component: BabysitterListComponent },
      { path: 'parents', component: ParentsListComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RelationshipsRoutingModule { }

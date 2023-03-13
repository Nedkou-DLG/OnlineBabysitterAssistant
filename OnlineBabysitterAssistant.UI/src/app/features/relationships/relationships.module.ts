import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RelationshipsRoutingModule } from './relationships-routing.module';
import { BabysitterListComponent } from './babysitter-list/babysitter-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ParentsListComponent } from './parents-list/parents-list.component';


@NgModule({
  declarations: [
    BabysitterListComponent,
    ParentsListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RelationshipsRoutingModule
  ]
})
export class RelationshipsModule { }

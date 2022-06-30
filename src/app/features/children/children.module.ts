import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChildrenRoutingModule } from './children-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChildrenListComponent } from './children-list/children-list.component';
import { AddActivityDialogComponent } from './add-activity-dialog/add-activity-dialog.component';
import { ViewChildComponent } from './view-child/view-child.component';
import { AssignBabysitterDialogComponent } from './assign-babysitter-dialog/assign-babysitter-dialog.component';
import { AddChildDialogComponent } from './add-child-dialog/add-child-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    ChildrenRoutingModule,
    SharedModule
  ],
  declarations: [
    ChildrenListComponent,
    AddActivityDialogComponent,
    ViewChildComponent,
    AssignBabysitterDialogComponent,
    AddChildDialogComponent
  ],
  entryComponents: [
  ]
})
export class ChildrenModule { }

import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NGXLogger } from 'ngx-logger';
import { Title } from '@angular/platform-browser';
import { NotificationService } from 'src/app/core/services/notification.service';
import { ParentsService } from 'src/app/core/services/api/parents.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AddActivityDialogComponent } from '../add-activity-dialog/add-activity-dialog.component';
import { AuthenticationService } from 'src/app/core/services/auth.service';
import { AddActivityModel } from 'src/app/shared/models/activity-model';
import { Router } from '@angular/router';
import { UserType } from 'src/app/shared/models/user-type';
import { AssignBabysitterDialogComponent } from '../assign-babysitter-dialog/assign-babysitter-dialog.component';
import { AddChildDialogComponent } from '../add-child-dialog/add-child-dialog.component';


@Component({
  selector: 'app-children-list',
  templateUrl: './children-list.component.html',
  styleUrls: ['./children-list.component.css']
})
export class ChildrenListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'gender', 'babysitter', 'actions'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  dialogRef!: MatDialogRef<AddActivityDialogComponent>
  dialogRefAssignBabysitter!: MatDialogRef<AssignBabysitterDialogComponent>
  dialogRefNewChild!: MatDialogRef<AddChildDialogComponent>
  @ViewChild(MatSort, { static: true })
  sort: MatSort = new MatSort;

  role: any;

  constructor(
    private logger: NGXLogger,
    private notificationService: NotificationService,
    private titleService: Title,
    private parentService: ParentsService,
    private dialog: MatDialog,
    private authService: AuthenticationService,
    private router: Router
  ) { }

  ngOnInit() {
    this.titleService.setTitle('Online Babysitter Assistant - Children');
    this.logger.log('Children loaded');
    this.role = this.authService.getCurrentUser().type;

    this.getMyChildren();
  }

  private getMyChildren() {
    this.parentService.getChildren().subscribe({
      next: data => {
        console.log(data);
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.sort = this.sort;
        this.notificationService.openSnackBar('Children loaded');
      },
      error: error => {
        console.log(error);
        this.notificationService.openSnackBar(error.error.message);
      }
    });
  }

  viewActivity(childId: number) {

    this.router.navigate(['/children/view-child', childId]);

  }

  addNewChild(){
    this.dialogRefNewChild = this.dialog.open(AddChildDialogComponent,{
      minHeight: '300px',
      minWidth: '400px',
    });
    this.dialogRefNewChild.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }

  assignBabysitter(childId: number) {
    this.dialogRefAssignBabysitter = this.dialog.open(AssignBabysitterDialogComponent, {
      minHeight: '300px',
      minWidth: '400px',
      data: {
        childId: childId
      }
    });
  }

  unassignBabysitter(childId: number) {
    this.parentService.unassignBabysitterFromChild(childId).subscribe({
      next: result => {
        this.getMyChildren();
      },
      error: error => {
        this.notificationService.openSnackBar(error.error.message);
      }
    })
  }

  addActivity(childId: number) {
    this.dialogRef = this.dialog.open(AddActivityDialogComponent, {
      minHeight: '300px',
      minWidth: '400px',
      data: {
        view: false
      }
    });

    this.dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      let model = <AddActivityModel>{
        childId: childId,
        time: result.time,
        description: result.description
      }
      // to be implemnted a api call for creating an activity for child (babysitter)
      this.parentService.addChildActivity(model).subscribe({
        next: result => {
          this.notificationService.openSnackBar("Succesfully added actvity to child!")
        },
        error: error => {
          this.notificationService.openSnackBar(error.error.message);
        }
      });
    })
  }
}

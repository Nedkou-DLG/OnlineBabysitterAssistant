import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { ParentsService } from 'src/app/core/services/api/parents.service';
import { NotificationService } from 'src/app/core/services/notification.service';

@Component({
  selector: 'app-babysitter-list',
  templateUrl: './babysitter-list.component.html',
  styleUrls: ['./babysitter-list.component.css']
})
export class BabysitterListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'email', 'address', 'phoneNumber','actions'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  @ViewChild(MatSort, { static: true })
  sort: MatSort = new MatSort;

  
  constructor(private parentService: ParentsService,
                      private notificationService: NotificationService,
                      private titleService: Title,) { }

  ngOnInit(): void {
    this.titleService.setTitle('Online Babysitter Assistant - Relationships');

    this.getAllBabysitters();
  }

  getAllBabysitters(){
    this.parentService.getAllBabysitters().subscribe({
      next: result =>{
        this.dataSource = new MatTableDataSource(result);
        this.notificationService.openSnackBar('Babysitters loaded successfully');
      },
      error: error => {
        this.notificationService.openSnackBar(error.error.message);
      }
    })
  }

  connectBabysitter(id: number){
    this.parentService.connectBabysitter(id).subscribe({
      next: result => {

        this.notificationService.openSnackBar('Successfully connected to babysitter!');
        this.getAllBabysitters();
      }, 
      error: error => {
        this.notificationService.openSnackBar(error.error.message);
      }
    })
  }

  disconnectBabysitter(id: number){
    this.parentService.disconnectBabysitter(id).subscribe({
      next: result => {
        this.notificationService.openSnackBar('Successfully disconected from babysitter!');
        this.getAllBabysitters();
      }
      , 
      error: error => {
        this.notificationService.openSnackBar(error.error.message);
      }
    });
  }
}

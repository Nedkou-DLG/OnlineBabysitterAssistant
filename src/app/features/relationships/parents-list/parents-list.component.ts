import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { ParentsService } from 'src/app/core/services/api/parents.service';
import { NotificationService } from 'src/app/core/services/notification.service';

@Component({
  selector: 'app-parents-list',
  templateUrl: './parents-list.component.html',
  styleUrls: ['./parents-list.component.css']
})
export class ParentsListComponent implements OnInit {

  displayedColumns: string[] = ['name', 'email', 'address', 'phoneNumber'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  @ViewChild(MatSort, { static: true })
  sort: MatSort = new MatSort;

  
  constructor(private parentService: ParentsService,
                      private notificationService: NotificationService,
                      private titleService: Title,) { }

  ngOnInit(): void {
    this.titleService.setTitle('Online Babysitter Assistant - Relationships');

    this.getMyParents();
  }

  getMyParents(){
    this.parentService.getMyParents().subscribe({
      next: result =>{
        this.dataSource = new MatTableDataSource(result);
        this.notificationService.openSnackBar('Parents loaded successfully');
      },
      error: error => {
        this.notificationService.openSnackBar(error.error.message);
      }
    })
  }
}

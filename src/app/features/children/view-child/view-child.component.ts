import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { ParentsService } from 'src/app/core/services/api/parents.service';
import { NotificationService } from 'src/app/core/services/notification.service';

@Component({
  selector: 'app-view-child',
  templateUrl: './view-child.component.html',
  styleUrls: ['./view-child.component.css']
})
export class ViewChildComponent implements OnInit {

  childId!: number;
  displayedColumns: string[] = ['time', 'description'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  @ViewChild(MatSort, { static: true })
  sort: MatSort = new MatSort;

  constructor(private route: ActivatedRoute,
              private parentService: ParentsService,
              private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.childId = Number(this.route.snapshot.paramMap.get('id'));

    this.parentService.getChildActivities(this.childId).subscribe({
      next: result => {
        result.forEach(x => {
          x.time = moment(x.time).format('MMM Do YYYY, kk:mm');
        })
        this.dataSource = new MatTableDataSource(result);
        this.dataSource.sort = this.sort;
        this.notificationService.openSnackBar('Child activities loaded');
      },
      error: error => {
        this.notificationService.openSnackBar(error.error.message);
      }
    })
  }

}

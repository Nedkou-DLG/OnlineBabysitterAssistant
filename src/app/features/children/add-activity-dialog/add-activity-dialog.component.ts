import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ParentsService } from 'src/app/core/services/api/parents.service';
import { AddActivityModel } from 'src/app/shared/models/activity-model';

@Component({
  selector: 'app-add-activity-dialog',
  templateUrl: './add-activity-dialog.component.html',
  styleUrls: ['./add-activity-dialog.component.css']
})
export class AddActivityDialogComponent implements OnInit {

  activityForm!: FormGroup;

  constructor(public dialogRef: MatDialogRef<AddActivityDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { view: boolean, childId: number },
    private parentService: ParentsService) { }

  ngOnInit() {
    this.activityForm = new FormGroup({
      time: new FormControl(null, Validators.required),
      description: new FormControl()
    })
    if(this.data.view){
      
      //get activites of child
    }
  }

  onClose(): void {
    this.dialogRef.close();
  }

  onAdd() {
    this.dialogRef.close(this.activityForm.value);
  }
}

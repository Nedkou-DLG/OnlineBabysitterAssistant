import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ParentsService } from 'src/app/core/services/api/parents.service';
import { UserModel } from 'src/app/shared/models/user-model';

@Component({
  selector: 'app-assign-babysitter-dialog',
  templateUrl: './assign-babysitter-dialog.component.html',
  styleUrls: ['./assign-babysitter-dialog.component.css']
})
export class AssignBabysitterDialogComponent implements OnInit {

  assignBabysitterForm!: FormGroup;
  babysittersDropdown: UserModel[] = [];
  constructor(public dialogRef: MatDialogRef<AssignBabysitterDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { parentId: number, childId: number },
    private parentService: ParentsService) { }

  ngOnInit() {
    this.assignBabysitterForm = new FormGroup({
      babysitter: new FormControl(null, Validators.required)
    })
    this.getParentBabysitters();
  }

  getParentBabysitters() {
    this.parentService.getParentBabysitters().subscribe({
      next: result => {
        this.babysittersDropdown = result;
      },
      error: error =>{

      }
    });
  }

  onClose(): void {
    this.dialogRef.close();
  }

  onAssign() {
    let babysitterId = this.assignBabysitterForm.get('babysitter')?.value;
    this.parentService.asssignBabysitterToChild( this.data.childId, babysitterId).subscribe({
      next: result => {
        this.onClose();
      },
      error: error =>{
        console.log(error.error.message);
      }
    });
    //this.dialogRef.close(this.assignBabysitterForm.value);
  }

}

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ParentsService } from 'src/app/core/services/api/parents.service';
import { AuthenticationService } from 'src/app/core/services/auth.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { AuthUser } from 'src/app/shared/models/auth-user';

@Component({
  selector: 'app-add-child-dialog',
  templateUrl: './add-child-dialog.component.html',
  styleUrls: ['./add-child-dialog.component.css']
})
export class AddChildDialogComponent implements OnInit {

  form!: FormGroup;
  loading!: boolean;
  constructor(private router: Router,
    private notificationService: NotificationService,
    private parentsService: ParentsService,
    private authService: AuthenticationService,
    public dialogRef: MatDialogRef<AddChildDialogComponent>) {
  }

  ngOnInit(): void {
    this.createForm();
  }

  private createForm() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      gender: new FormControl('', [Validators.required]),
      
    });
  }

  onClose(){
    this.dialogRef.close();
  }

  onCreate(){
    let child = {
      name: this.form.get('name')?.value,
      gender: this.form.get('gender')?.value

    }
    this.parentsService.addNewChild(child).subscribe({
      next: result => {
        this.notificationService.openSnackBar("Succesfully added new child!")
        this.onClose();
      },
      error: error => {
        this.notificationService.openSnackBar(error.error.message);
      }
    });
  }
}

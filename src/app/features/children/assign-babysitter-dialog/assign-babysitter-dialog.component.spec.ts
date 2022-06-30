import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignBabysitterDialogComponent } from './assign-babysitter-dialog.component';

describe('AssignBabysitterDialogComponent', () => {
  let component: AssignBabysitterDialogComponent;
  let fixture: ComponentFixture<AssignBabysitterDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignBabysitterDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignBabysitterDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

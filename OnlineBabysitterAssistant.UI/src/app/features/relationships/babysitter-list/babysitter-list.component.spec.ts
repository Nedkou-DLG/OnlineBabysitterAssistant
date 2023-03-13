import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BabysitterListComponent } from './babysitter-list.component';

describe('BabysitterListComponent', () => {
  let component: BabysitterListComponent;
  let fixture: ComponentFixture<BabysitterListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BabysitterListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BabysitterListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

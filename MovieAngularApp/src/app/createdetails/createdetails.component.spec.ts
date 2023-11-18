import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatedetailsComponent } from './createdetails.component';

describe('CreatedetailsComponent', () => {
  let component: CreatedetailsComponent;
  let fixture: ComponentFixture<CreatedetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatedetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatedetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

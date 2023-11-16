import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FindmovieComponent } from './findmovie.component';

describe('FindmovieComponent', () => {
  let component: FindmovieComponent;
  let fixture: ComponentFixture<FindmovieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FindmovieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FindmovieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

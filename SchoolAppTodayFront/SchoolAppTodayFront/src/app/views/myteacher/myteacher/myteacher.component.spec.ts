import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyteacherComponent } from './myteacher.component';

describe('MyteacherComponent', () => {
  let component: MyteacherComponent;
  let fixture: ComponentFixture<MyteacherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyteacherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyteacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAdministratorComponent } from './user-administrator.component';

describe('UserAdministratorComponent', () => {
  let component: UserAdministratorComponent;
  let fixture: ComponentFixture<UserAdministratorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserAdministratorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserAdministratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

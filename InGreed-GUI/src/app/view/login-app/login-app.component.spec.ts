import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginAppComponent } from './login-app.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('LoginAppComponent', () => {
  let component: LoginAppComponent;
  let fixture: ComponentFixture<LoginAppComponent>;
 
  beforeEach(async () => {
     await TestBed.configureTestingModule({
       imports: [
         HttpClientTestingModule, 
       ]
     }).compileComponents();
 
     fixture = TestBed.createComponent(LoginAppComponent);
     component = fixture.componentInstance;
     fixture.detectChanges();
  });
 
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

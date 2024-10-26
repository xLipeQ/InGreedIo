import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterAppComponent } from './register-app.component';
import { LoginService } from '../../core/services/login/login.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('RegisterAppComponent', () => {
  let component: RegisterAppComponent;
  let fixture: ComponentFixture<RegisterAppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

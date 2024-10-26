import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthenticateSharedComponent } from './authenticate-shared.component';
import { Router } from '@angular/router';

describe('AuthenticateSharedComponent', () => {
 let component: AuthenticateSharedComponent;
 let fixture: ComponentFixture<AuthenticateSharedComponent>;

 beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, RouterTestingModule]
    }).compileComponents();
 });

 beforeEach(() => {
    fixture = TestBed.createComponent(AuthenticateSharedComponent);
    component = fixture.componentInstance;
    component.isLogin = false;
    fixture.detectChanges();
 });

 it('should create the form with the correct controls and validators', () => {
    expect(component.loginForm.get('email')).toBeTruthy();
    expect(component.loginForm.get('password')).toBeTruthy();
    expect(component.loginForm.get('secondPassword')).toBeTruthy();
    expect(component.loginForm.get('email')?.validator).toBeTruthy();
    expect(component.loginForm.get('password')?.validator).toBeTruthy();
    expect(component.loginForm.get('secondPassword')?.validator).toBeTruthy();
 });

 it('should validate that passwords match', () => {
   component.loginForm.get('email')?.setValue("mail@gmail.com")
    component.loginForm.get('password')?.setValue('password123');
    component.loginForm.get('secondPassword')?.setValue('password123');
    expect(component.loginForm.valid).toBeTrue();

    component.loginForm.get('secondPassword')?.setValue('password1234');
    expect(component.loginForm.valid).toBeFalse();
    expect(component.loginForm.errors).toEqual({ notSame: true });
 });

 it('should not submit the form if it is invalid', () => {
    spyOn(component, 'callbackActionSubmit');
    component.loginForm.get('email')?.setValue('');
    component.onSubmit();
    expect(component.callbackActionSubmit).not.toHaveBeenCalled();
 });

 it('should submit the form if it is valid', () => {
    spyOn(component, 'callbackActionSubmit');
    component.loginForm.get('email')?.setValue('test@example.com');
    component.loginForm.get('password')?.setValue('password123');
    component.loginForm.get('secondPassword')?.setValue('password123');
    component.onSubmit();
    expect(component.callbackActionSubmit).toHaveBeenCalledWith(component.loginForm);
 });

 it('should navigate to the register page', () => {
    const router = TestBed.inject(Router);
    spyOn(router, 'navigate');
    component.showRegisterPage();
    expect(router.navigate).toHaveBeenCalledWith(['register']);
 });
});
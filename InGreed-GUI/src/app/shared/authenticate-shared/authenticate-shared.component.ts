import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { paths } from '../../app-paths';
import { FormGroup, ValidatorFn, ValidationErrors, FormBuilder, Validators  } from '@angular/forms';
import { enumRole } from '../../core/models/enums/role.enum';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { selectIsErrorOccured } from '../../core/store/jwt-token/jwt-token.selectors';
import { resetHasErrorOccured } from '../../core/store/jwt-token/jwt-token.actions';

export function checkPasswords(group: FormGroup): ValidationErrors | null {
  if (group == null) return null;

  let pass = group.get('password')?.value;
  let confirmPass = group.get('secondPassword')?.value;
  return pass === confirmPass ? null : { notSame: true };
 }

@Component({
  selector: 'ingreedio-authenticate-shared',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule ],
  templateUrl: './authenticate-shared.component.html',
  styleUrl: './authenticate-shared.component.scss'
})
export class AuthenticateSharedComponent implements OnInit{
  loginForm: FormGroup = this.fb.group({})
  submittedError: boolean = false;
  selectedRole: enumRole = enumRole.Client;
  RoleEnum = enumRole;
  hasErrorOccured$: Observable<boolean>;

  @Input() isLogin: boolean = true;
  @Input() callbackActionSubmit: (formData: any) => void;
  @Input() callbackValidate: () => void;
  @Input() header: string = '';

  constructor(private router: Router, private fb: FormBuilder, private store: Store) {
    this.resetHasErrorOccured();
    this.callbackActionSubmit = () => {}
    this.callbackValidate = () => {}
    this.hasErrorOccured$ = this.store.select(selectIsErrorOccured)
  }

  resetHasErrorOccured() {
    this.store.dispatch(resetHasErrorOccured())
  }

  ngOnInit(): void {

    if (this.isLogin) {
      this.loginForm = this.fb.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required],
      });
    } else {
      this.loginForm = this.fb.group({
        username: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required],
        secondPassword: ['', Validators.required],
        selectedRole: [enumRole.Client, Validators.required]
      }, { validators: checkPasswords });
    }
  }

  onSubmit() {
    this.submittedError = !this.loginForm.valid

    if (!this.loginForm.valid) {
      this.resetInvalidControls(this.loginForm)
      return;
    }

    this.callbackActionSubmit(this.loginForm)
   }

  resetInvalidControls(form: FormGroup) {
    if (!this.isLogin) {
      if (form.errors?.['notSame']) {
        form.controls['password'].reset();
        form.controls['secondPassword'].reset();
      }
    }

    if (form.controls['email'].invalid) {
      form.controls['email'].reset();
    }
  }

  pickRole(role: enumRole) {
    this.loginForm.patchValue({
    selectedRole: role
  });
    this.selectedRole = role;
  }

  showRegisterPage() {
    this.router.navigate([paths.register])
  }
}

import { Component, OnDestroy, OnInit } from '@angular/core';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';
import { FormGroup, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthenticateSharedComponent } from '../../shared/authenticate-shared/authenticate-shared.component';
import { LoginRequest } from '../../core/models/models/login.request';
import { Store } from '@ngrx/store';
import { initJwtToken } from '../../core/store/jwt-token/jwt-token.actions';
import { selectIsErrorOccured, selectIsJwtTokenSet, selectJwtToken } from '../../core/store/jwt-token/jwt-token.selectors';
import { Observable, Subscription, take } from 'rxjs';
import { LoginService } from '../../core/services/login/login.service';
import { JwtTokenState } from '../../core/store/jwt-token/jwt-token.state';

@Component({
  selector: 'ingreedio-login-app',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent, FormsModule, CommonModule, AuthenticateSharedComponent ],
  templateUrl: './login-app.component.html',
  styleUrl: './login-app.component.scss',
})
export class LoginAppComponent {
  submittedError: boolean = false;

  constructor(private store: Store, private loginService: LoginService) {}

  async onSubmit(formData: FormGroup) {
    const request: LoginRequest = {
      login: formData.get('email')?.value,
      password: formData.get('password')?.value
    };
    await this.store.dispatch(initJwtToken({ request: this.loginService.login(request) }))
  }
}

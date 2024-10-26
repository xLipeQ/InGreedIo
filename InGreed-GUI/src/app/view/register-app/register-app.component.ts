import { Component } from '@angular/core';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';
import { AuthenticateSharedComponent } from '../../shared/authenticate-shared/authenticate-shared.component';
import { RegistrationRequest } from '../../core/models/models/registration.request';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { initJwtToken } from '../../core/store/jwt-token/jwt-token.actions';
import { selectIsJwtTokenSet } from '../../core/store/jwt-token/jwt-token.selectors';
import { LoginService } from '../../core/services/login/login.service';
import { getIndexOfEnumRole } from '../../core/models/enums/role.enum';

@Component({
  selector: 'ingreedio-register-app',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent, AuthenticateSharedComponent],
  templateUrl: './register-app.component.html',
  styleUrl: './register-app.component.scss'
})
export class RegisterAppComponent {
  constructor(private store: Store, private loginService: LoginService) {}

  async onSubmit(formData: any) {
    var request: RegistrationRequest;
    var enumIndex = getIndexOfEnumRole(formData.get('selectedRole')?.value);
    request = { username: formData.get('username')?.value, mail: formData.get('email')?.value, password: formData.get('password')?.value, role: enumIndex };

    await this.store.dispatch(initJwtToken({ request: this.loginService.registration(request) }))
  }
}

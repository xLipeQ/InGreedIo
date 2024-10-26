import { ServiceBase } from '../service-base/service.base';
import { Observable } from 'rxjs';
import { LoginRequest } from '../../models/models/login.request';
import { RegistrationRequest } from '../../models/models/registration.request';
import { Injectable } from '@angular/core';
import { LoginResponse } from '../../models/models/login.response';


@Injectable({
  providedIn: 'root',
})
export class LoginService extends ServiceBase {

  login(body: LoginRequest | undefined): Observable<LoginResponse> {
      let url_ = this.baseUrl + "/api/Login";
      url_ = url_.replace(/[?&]$/, "");
      return this.httpClient.post<LoginResponse>(url_, body);
  }

  registration(body: RegistrationRequest | undefined): Observable<LoginResponse> {
    let url_ = this.baseUrl + "/api/Registration";
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.post<LoginResponse>(url_, body);
  }
}
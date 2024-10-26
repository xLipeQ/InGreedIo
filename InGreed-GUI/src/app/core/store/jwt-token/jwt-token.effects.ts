import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { initJwtToken, loadJwtTokenSuccess, resetJwtToken } from './jwt-token.actions';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { SignalrService } from '../../services/signalr/signalr.service';
import { CookieService } from 'ngx-cookie-service';
import { JWT_TOKEN_FIELD } from '../../constants/constants';
@Injectable()
export class JwtTokenEffects {
  constructor(
    private actions$: Actions,
    private router: Router,
    private signalrService: SignalrService,
    private cookieService: CookieService
  ) { }

    private jwtHelper: JwtHelperService = new JwtHelperService();


    loadJwtToken$ = createEffect(() =>
      this.actions$.pipe(
        ofType(initJwtToken),
        switchMap(({ request }) => {
          return request.pipe(
            map(response => {
              const jwtToken = response.jwtToken;
              const userId = this.jwtHelper.decodeToken(jwtToken as string)['Id'];
              this.signalrService.initiateSignalrConnection(userId);
              this.router.navigate(['/']);
              this.cookieService.set(JWT_TOKEN_FIELD, jwtToken, 1);
              return loadJwtTokenSuccess({ jwtToken: jwtToken, isSet: true });
            }),
            catchError(error => {
              this.cookieService.delete(JWT_TOKEN_FIELD)
              return of(resetJwtToken())
            })
          );
        })
      )
    );
}
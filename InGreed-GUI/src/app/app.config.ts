import { ApplicationConfig, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { jwtTokenReducer } from './core/store/jwt-token/jwt-token.reducers';
import { provideEffects } from '@ngrx/effects';
import { JwtTokenEffects } from './core/store/jwt-token/jwt-token.effects';
import { authInterceptor } from './core/auth/interceptor/auth.interceptor';
import { JwtHelperService, JWT_OPTIONS  } from '@auth0/angular-jwt';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideClientHydration(),
    provideHttpClient(withInterceptors([authInterceptor])),
    provideStore({jwtToken: jwtTokenReducer}),
    provideStoreDevtools({
      maxAge: 25, // Retains last 25 states
      logOnly: !isDevMode(), // Restrict extension to log-only mode
      autoPause: true, // Pauses recording actions and state changes when the extension window is not open
      trace: false, //  If set to true, will include stack trace for every dispatched action, so you can see it in trace tab jumping directly to that part of code
      traceLimit: 75, // maximum stack trace frames to be stored (in case trace option was provided as true)
    }),
    provideEffects([JwtTokenEffects]),
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService
],
};

import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectJwtToken } from '../../store/jwt-token/jwt-token.selectors';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const store = inject(Store) 
  const jwtToken$ = store.select(selectJwtToken) 
  let myJwtToken: String = ''

  jwtToken$.subscribe(jwtToken => {
    myJwtToken = jwtToken
  })

  const modifiedReq = req.clone({
    headers: req.headers.set('Authorization', `Bearer ${myJwtToken}`)
  });
  
  return next(modifiedReq);
};

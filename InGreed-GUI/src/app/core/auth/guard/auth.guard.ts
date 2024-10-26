import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { isJwtSet, navigateToHomeIfFalse } from '../../utils/utils';

export const authGuard: CanActivateFn = (route, state) => {
  const store = inject(Store);
  const isSet: boolean = isJwtSet(store);
  navigateToHomeIfFalse(isSet)

  return isSet;
};

import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { checkIfJwtTokenRoleIsEqual, getJwtToken, navigateToHomeIfFalse } from '../../utils/utils';
import { ROLES_JWT_FIELD } from '../../constants/constants';
import { enumRole } from '../../models/enums/role.enum';

export const clientAuthGuard: CanActivateFn = (route, state) => {
  const isEqual = checkIfJwtTokenRoleIsEqual(enumRole.Client)
  navigateToHomeIfFalse(isEqual)
  return isEqual
};

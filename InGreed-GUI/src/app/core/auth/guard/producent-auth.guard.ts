import { CanActivateFn } from '@angular/router';
import { checkIfJwtTokenRoleIsEqual, navigateToHomeIfFalse } from '../../utils/utils';
import { enumRole } from '../../models/enums/role.enum';

export const producentAuthGuard: CanActivateFn = (route, state) => {
  const isEqual = checkIfJwtTokenRoleIsEqual(enumRole.Producent)
  navigateToHomeIfFalse(isEqual)
  return isEqual
};

import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { producentAuthGuard } from './producent-auth.guard';

describe('producentAuthGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => producentAuthGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});

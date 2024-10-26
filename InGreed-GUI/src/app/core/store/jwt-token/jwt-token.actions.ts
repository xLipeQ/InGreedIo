import { createAction, props } from '@ngrx/store';
import { Observable } from 'rxjs/internal/Observable';

export const initJwtToken = createAction(
    '[JWT] init authorization data',
    props<{ request: Observable<any> }>()
);

export const loadJwtTokenSuccess = createAction(
    '[JWT] Load JWT token success', 
    props<{ jwtToken: string, isSet: boolean }>()
)

export const resetJwtToken = createAction(
    '[JWT] Reset JWT token'
)

export const resetHasErrorOccured = createAction(
    '[JWT] Reset hasErrorOccured'
)

import { createReducer, createSelector, on } from '@ngrx/store';
import { initJwtToken, resetJwtToken, loadJwtTokenSuccess, resetHasErrorOccured } from './jwt-token.actions';
import { initialState } from './jwt-token.state';

export const jwtTokenReducer = createReducer(
  initialState,
  on(initJwtToken, (state) => ({...state})),
  on(loadJwtTokenSuccess, (state, { jwtToken, isSet }) => ({ ...state, jwtToken: jwtToken, isSet: isSet, errorOccured: false})),
  on(resetJwtToken, (state) => ({ ...state, jwtToken: "", isSet: false, errorOccured: true})),
  on(resetHasErrorOccured, (state) => ({...state, errorOccured: false}))
);
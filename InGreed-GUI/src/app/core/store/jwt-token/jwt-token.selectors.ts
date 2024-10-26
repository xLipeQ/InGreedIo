import { createFeatureSelector, createSelector } from "@ngrx/store";
import { JwtTokenState } from "./jwt-token.state";

export const jwtTokenStateSelector = createFeatureSelector<JwtTokenState>("jwtToken")

export const selectJwtToken = createSelector(
  jwtTokenStateSelector,
    (state: JwtTokenState) => state.jwtToken
);
  
export const selectIsJwtTokenSet = createSelector(
  jwtTokenStateSelector,
    (state: JwtTokenState) => state.isSet
  );

export const selectIsErrorOccured = createSelector(
  jwtTokenStateSelector,
    (state: JwtTokenState) => state.errorOccured
  );
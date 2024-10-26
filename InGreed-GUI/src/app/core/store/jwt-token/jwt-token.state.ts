export interface JwtTokenState {
    jwtToken: String;
    isSet: boolean;
    errorOccured: boolean;
}
  
export const initialState: JwtTokenState = {
    jwtToken: '',
    isSet: false,
    errorOccured: false
}
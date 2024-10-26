export interface PreferenceRequest{
    userId : number;
    ingredientId : number;
    type : number | undefined;
}

export interface MultiplePreferenceRequest{
    userId : number;
    ingredientIds : number[];
}
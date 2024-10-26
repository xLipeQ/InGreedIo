import { CategoryResponse } from "./category.response";
import { IngredientResponse } from "./ingredient.response";

export class SearchProductsPropsModel {
    showOnlyFavourite: boolean;
    category: CategoryResponse | undefined;
    searchPhrase: string;
    ingredients: IngredientResponse[]

    constructor(
        category: CategoryResponse | undefined = undefined,
        searchPhrase: string = "",
        ingredients: IngredientResponse[] = [],
        showOnlyFavourite: boolean = false
    ) {
        this.showOnlyFavourite = showOnlyFavourite
        this.category = category;
        this.searchPhrase = searchPhrase;
        this.ingredients = ingredients
    }
}
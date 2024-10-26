import { CategoryResponse } from "./category.response"
import { IngredientResponse } from "./ingredient.response"

export class ProductAddRequest {
    ProducentID: number = 0
    ProductName: string = ''
    Description: string = ''
    Category: CategoryResponse = {id: 0, name: ''}
    Ingredients: IngredientResponse[] = []

    constructor() {
    }
}
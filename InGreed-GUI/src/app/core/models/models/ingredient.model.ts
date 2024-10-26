export class IngredientModel {
    name: string

    constructor(name: string) {
        this.name = name
    }

    toString(): string {
        return `${name}`
    }
}
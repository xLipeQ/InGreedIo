import { ProductModel } from "./product.model";

export interface ProductResponse {
    productRows: ProductModel[];
    numberOfPages: number;
}
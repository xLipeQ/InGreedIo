import { Injectable } from '@angular/core';
import { ServiceBase } from '../service-base/service.base';
import { IngredientResponse } from '../../models/models/ingredient.response';

@Injectable({
  providedIn: 'root',
})
export class IngredientsDataService extends ServiceBase {

  getIngredients() {
    let url_ = this.baseUrl + "/api/Ingredient";
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.get<IngredientResponse[]>(url_);
  }

  getIngredientsForProduct(productId: number) {
    let url_ = this.baseUrl + `/api/Ingredient/Product`;
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.get<IngredientResponse[]>(url_, {params: {productId: productId}});
  }

  getIngredientsWithPatern(pattern : string) {
    let url_ = this.baseUrl + "/api/Ingredient/Pattern";
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.get<IngredientResponse[]>(url_, { params: {pattern: pattern}});
  }
}

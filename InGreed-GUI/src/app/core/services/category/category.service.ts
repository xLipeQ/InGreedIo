import { Injectable } from '@angular/core';
import { ServiceBase } from '../service-base/service.base';
import { CategoryResponse } from '../../models/models/category.response';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends ServiceBase {

  getCategories() {
    let url_ = this.baseUrl + "/api/Category";
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.get<CategoryResponse[]>(url_);
  }

  getCategoriesWithPatern(pattern : string) {
    let url_ = this.baseUrl + "/api/Category/Pattern";
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.get<CategoryResponse[]>(url_, { params: {pattern: pattern}});
  }
}

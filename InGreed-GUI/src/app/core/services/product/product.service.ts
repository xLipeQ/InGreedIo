import { Injectable } from '@angular/core';
import { ServiceBase } from '../service-base/service.base';
import { ProductAddRequest } from '../../models/models/product-add-request';
import { ProductResponse } from '../../models/models/product.response';
import { SearchProductsPropsModel } from '../../models/models/search-products-props.model';
import { Observable } from 'rxjs';
import { ProductRequest } from '../../models/models/product-request';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpHeaders } from '@angular/common/http';
import { ReadVarExpr } from '@angular/compiler';
import { Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends ServiceBase{

  private jwtHelper: JwtHelperService = new JwtHelperService();

  get(productRequest: ProductRequest) : Observable<ProductResponse>{
    let url_ = this.baseUrl + "/api/Product";
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.get<ProductResponse>(url_, {params: productRequest as any});
  }

  getImage(productId : number) : Observable<Blob>{
    let url_ = this.baseUrl + `/api/Product/Image`;
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.get(url_, {params: {productId: productId}, responseType: "blob"});
  }

  postFavourite(token: String, productId: number){
    let userId = this.jwtHelper.decodeToken(token as string)['Id']
    let url_ = this.baseUrl + `/api/Product/FavouriteProduct`;
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.post(url_, null, {
      params: {userId: userId, productId: productId},
      headers: {'Authorization': `bearer ${token}`}});
  }

  deleteFavourite(token: String, productId: number){
    let userId = this.jwtHelper.decodeToken(token as string)['Id']
    let url_ = this.baseUrl + `/api/Product/FavouriteProduct`;
    url_ = url_.replace(/[?&]$/, "");

    return this.httpClient.delete(url_, {
      params: {userId: userId, productId: productId},
      headers: {'Authorization': `bearer ${token}`}});
  }
}

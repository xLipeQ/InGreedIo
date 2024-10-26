import { Injectable } from '@angular/core';
import { ServiceBase } from '../service-base/service.base';
import { ProductAddRequest } from '../../models/models/product-add-request';

@Injectable({
  providedIn: 'root'
})
export class ProductAddService extends ServiceBase{

  postProduct(productAddRequest: FormData){
    let url_ = this.baseUrl + "/api/Product/Add";
    url_ = url_.replace(/[?&]$/, "");
    return this.httpClient.post<void>(url_, productAddRequest);
  }
}

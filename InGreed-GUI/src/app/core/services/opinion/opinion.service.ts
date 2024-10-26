import { Observable } from "rxjs";
import { ServiceBase } from "../service-base/service.base";
import { OpinionResponse } from "../../models/models/opinion.response";
import { Injectable } from '@angular/core';
import { OpinionRequest } from "../../models/models/opinion.request";

@Injectable({
    providedIn: 'root'
  })
export class OpinionService extends ServiceBase{
    getOpinionForProduct(productId : number){
        let url_ = this.baseUrl + `/api/Opinion`;
        url_ = url_.replace(/[?&]$/, "");

        return this.httpClient.get<OpinionResponse[]>(url_, {params: {productId: productId}});
    }

    postOpinion(requset : OpinionRequest, token : string): Observable<void> {
        let url_ = this.baseUrl + "/api/Opinion";
        url_ = url_.replace(/[?&]$/, "");
        
        return this.httpClient.post<void>(url_, requset, {headers: {'Authorization': `bearer ${token}`}});
    }

    putOpinion(requset : OpinionRequest, token : string): Observable<void> {
        let url_ = this.baseUrl + "/api/Opinion";
        url_ = url_.replace(/[?&]$/, "");
        
        return this.httpClient.put<void>(url_, null);
    }

    deleteOpinion(productId : number, userId : number, token : string): Observable<void> {
        let url_ = this.baseUrl + `/api/Opinion`;
        url_ = url_.replace(/[?&]$/, "");

        return this.httpClient.delete<void>(url_, {
            params: {productId: productId, userId: userId},
            headers: {'Authorization': `bearer ${token}`}});
    }
}
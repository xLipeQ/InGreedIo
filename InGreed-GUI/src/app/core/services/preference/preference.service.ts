import { ServiceBase } from "../service-base/service.base";
import { Observable } from "rxjs";
import { OpinionResponse } from "../../models/models/opinion.response";
import { Injectable } from '@angular/core';
import { MultiplePreferenceRequest, PreferenceRequest } from "../../models/models/preference.request";
import { PreferenceResponse } from "../../models/models/preference.response";


@Injectable({
    providedIn: 'root'
  })

export class PreferenceService extends ServiceBase{
    postPreference(request : PreferenceRequest, token : string){
        let url_ = this.baseUrl + "/api/Preference";
        url_ = url_.replace(/[?&]$/, "");
        
        return this.httpClient.post<void>(url_, request, {headers: {'Authorization': `bearer ${token}`}});
    }

    getPreference(request : MultiplePreferenceRequest, token : string) : Observable<PreferenceResponse[]>{
        let url_ = this.baseUrl + "/api/Preference";
        url_ = url_.replace(/[?&]$/, "");
        
        return this.httpClient.get<PreferenceResponse[]>(url_, {params: request as any, headers: {'Authorization': `bearer ${token}`}});
    }

    getUserPreference(userId : number, token : string) : Observable<PreferenceResponse[]>{
        let url_ = this.baseUrl + "/api/Preference/User";
        url_ = url_.replace(/[?&]$/, "");
        
        return this.httpClient.get<PreferenceResponse[]>(url_, {params: {userId: userId}, headers: {'Authorization': `bearer ${token}`}});
    }

    deletePreference(request : PreferenceRequest, token : string){
        let url_ = this.baseUrl + "/api/Preference";
        url_ = url_.replace(/[?&]$/, "");
        
        return this.httpClient.delete<void>(url_, {body: request, headers: {'Authorization': `bearer ${token}`}});
    }
}
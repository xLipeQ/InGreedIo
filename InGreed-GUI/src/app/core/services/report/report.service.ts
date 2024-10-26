import { ServiceBase } from "../service-base/service.base";
import { Injectable } from '@angular/core';
import { ReportRequest } from "../../models/models/report.request";


@Injectable({
    providedIn: 'root'
  })

export class ReportService extends ServiceBase{
    postReport(request : ReportRequest, token : string){
        let url_ = this.baseUrl + "/api/Report";
        url_ = url_.replace(/[?&]$/, "");
        
        return this.httpClient.post<void>(url_, request, {headers: {'Authorization': `bearer ${token}`}});
    }
}
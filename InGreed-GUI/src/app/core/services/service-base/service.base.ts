import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { inject } from "@angular/core";

@Injectable({
    providedIn: 'root'
  })

export class ServiceBase{
    protected baseUrl = 'https://localhost:7118';
    protected httpClient : HttpClient;
    constructor()
    {
        this.httpClient = inject(HttpClient);
    }

}
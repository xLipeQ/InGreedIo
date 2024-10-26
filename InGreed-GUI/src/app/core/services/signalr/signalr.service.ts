import { Injectable } from '@angular/core';
import { ServiceBase } from '../service-base/service.base';
import { environment } from '../../../../environments/environment';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService extends ServiceBase {
  signalrHubUrl = this.baseUrl + '/signalrhub';
  connection: any;

  public async initiateSignalrConnection(userId: string): Promise<void> {
    try {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl(`${this.signalrHubUrl}?userId=${userId}`)
        .withAutomaticReconnect()
        .build();

      this.connection.on('Ban', (reason: string) => {
        console.log(`Ban reason: ${reason}`);
      });

      await this.connection.start();

      console.log(`SignalR connection success! connectionId: ${this.connection.connectionId}`);
    }
    catch (error) {
      console.log(`SignalR connection error: ${error}`);
    }
  }
}

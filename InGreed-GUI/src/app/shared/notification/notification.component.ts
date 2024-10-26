import { Component, OnInit } from '@angular/core';
import { NotificationService, Notification } from '../../core/services/notification/notification.service';
import { NgFor, NgClass } from '@angular/common';

@Component({
  selector: 'ingreedio-notification',
  standalone: true,
  imports: [NgFor, NgClass],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.scss'
})
export class NotificationComponent {
  notifications: Notification[] = [];

  constructor(private notificationService: NotificationService) {}

  ngOnInit() {
    this.notificationService.notifications$.subscribe(notification => {
      this.notifications.push(notification);
      setTimeout(() => {
        this.removeNotification(notification);
      }, 2000); // Auto-hide notifications after 2 seconds
    });
  }

  removeNotification(notification: Notification) {
    this.notifications = this.notifications.filter(notif => notif !== notification);
  }
}

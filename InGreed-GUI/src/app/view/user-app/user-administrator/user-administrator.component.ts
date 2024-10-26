import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LogService } from '../../../core/services/log/log.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'ingreedio-user-administrator',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user-administrator.component.html',
  styleUrl: './user-administrator.component.scss'
})
export class UserAdministratorComponent {
  selectedDateTime = this.formatDate(new Date());

  constructor(private logService: LogService) { }

  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  getLogs() {
    this.logService.getLogFile({ date: this.selectedDateTime }).subscribe((response: any) => {
      const blob = new Blob([response], {type: 'application/json'});

      var downloadURL = window.URL.createObjectURL(response);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = this.selectedDateTime + ".log";
      link.click();
    })
  }
}

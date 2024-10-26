import { Component } from '@angular/core';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';

@Component({
  selector: 'ingreedio-about-app',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent],
  templateUrl: './about-app.component.html',
  styleUrl: './about-app.component.scss'
})
export class AboutAppComponent {

}

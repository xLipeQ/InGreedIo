import { Component } from '@angular/core';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';

@Component({
  selector: 'ingreedio-pricing-app',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent],
  templateUrl: './pricing-app.component.html',
  styleUrl: './pricing-app.component.scss'
})
export class PricingAppComponent {

}
